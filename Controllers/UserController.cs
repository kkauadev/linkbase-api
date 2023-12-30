using AutoMapper;
using LinkBaseApi.Services;
using LinkBaseApi.Context;
using LinkBaseApi.DTOs;
using LinkBaseApi.Helpers;
using LinkBaseApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinkBaseApi.Controllers
{
  public class UserController: ControllerBase
  {
    public readonly ILogger<UserController> _logger;
    public readonly DataContext _dataContext;
    public readonly IMapper _mapper;
    public readonly ValidationService _validationService;
    public UserController(ILogger<UserController> logger, DataContext dataContext, IMapper mapper, ValidationService validationService) { 
      _logger = logger;
      _dataContext = dataContext;
      _mapper = mapper;
      _validationService = validationService;
    }

    [HttpGet("/users")]
    public async Task<ActionResult<List<User>>> GetAll()
    {
      return await _dataContext.Users.ToListAsync();
    }

    [HttpGet("/user/{id}")]
    public async Task<ActionResult<User>> GetUserById(string id)
    {
      if (!Guid.TryParse(id, out Guid userId)) 
      {
        return BadRequest("Insira um id válido");
      }

      User? user = await _dataContext.Users.FindAsync(userId);

      if (user == null) 
      { 
        return NotFound();
      }

      return Ok(user);
    }

    [HttpPost("/user")]
    public async Task<ActionResult<User>> Post([FromBody] UserDTO userDTO)
    {
      var (isValid, errorMessage) = _validationService.ValidateUserCreation(userDTO);
      if (!isValid)
      {
        return BadRequest(errorMessage);
      }

      if (_dataContext.Users.Any(u => u.Email == userDTO.Email || u.Username == userDTO.Username))
      {
        return BadRequest("Este e-mail ou username já está sendo utilizado.");
      }

      PasswordHasher passwordHasher = new();
      userDTO.Password = passwordHasher.HashPassword(userDTO.Password);

      User user = _mapper.Map<User>(userDTO);

      _dataContext.Users.Add(user);
      await _dataContext.SaveChangesAsync();

      return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    [HttpPatch("/user/{id}")]
    public async Task<ActionResult<User>> PatchUserById(string id, [FromBody] UserUpdateDTO userDTO)
    {
      if (!Guid.TryParse(id, out Guid userId))
      {
        return BadRequest("Insira um ID válido");
      }

      User? existingUser = await _dataContext.Users.FindAsync(userId);
      if (existingUser == null)
      {
        return NotFound("Usuário não encontrado");
      }

      if (!string.IsNullOrEmpty(userDTO.Password) && userDTO.Password.Length >= 8)
      {
        PasswordHasher passwordHasher = new();
        existingUser.Password = passwordHasher.HashPassword(userDTO.Password);
      }

      if (!string.IsNullOrEmpty(userDTO.Name))
      {
        existingUser.Name = userDTO.Name;
      }

      if (!string.IsNullOrEmpty(userDTO.Bio))
      {
        existingUser.Bio = userDTO.Bio;
      }

      await _dataContext.SaveChangesAsync();

      return Ok($"Usuário {existingUser.Username} atualizado com sucesso");
    }

    [HttpPatch("/user/bio/{id}")]
    public async Task<ActionResult> UpdateUserBio(string id, [FromBody] string bio)
    {
      if (!Guid.TryParse(id, out Guid userId))
      {
        return BadRequest("Insira um ID válido");
      }
      if (string.IsNullOrEmpty(bio))
      {
        return BadRequest("A Bio não pode ser vazia");
      }

      User? user = await _dataContext.Users.FindAsync(userId);

      if (user == null) 
      {
        return NotFound("Usuário não encontrado");
      }

      user.Bio = bio;

      _dataContext.Update(user);
      await _dataContext.SaveChangesAsync();

      return Ok();
    }

    [HttpDelete("/user/{id}")]
    public async Task<ActionResult> DeleteUserById(string id)
    {
      if (!Guid.TryParse(id, out Guid userId))
      {
        return BadRequest("Insira um id válido");
      }

      User? user = await _dataContext.Users.FindAsync(userId);

      if (user == null)
      {
        return BadRequest();
      }

      _dataContext.Users.Remove(user);
      await _dataContext.SaveChangesAsync();

      return Ok($"Usuário ({user.Username} - {user.Id}) removido com sucesso");
    }
  }
}
