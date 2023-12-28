using AutoMapper;
using linkbase_api.Context;
using linkbase_api.DTOs;
using linkbase_api.Helpers;
using linkbase_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace linkbase_api.Controllers
{
  public class UserController: ControllerBase
  {
    public readonly ILogger<UserController> _logger;
    public readonly DataContext _dataContext;
    public readonly IMapper _mapper;
    public UserController(ILogger<UserController> logger, DataContext dataContext, IMapper mapper) { 
      _logger = logger;
      _dataContext = dataContext;
      _mapper = mapper;
    }

    [HttpGet("/users")]
    public async Task<ActionResult<List<User>>> GetAll()
    {
      List<User> users = await _dataContext.Users.ToListAsync();
      Console.WriteLine("Funcionou");
      return users;
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
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (_dataContext.Users.Any(u => u.Email == userDTO.Email || u.Username == userDTO.Username))
      {
        ModelState.AddModelError("Campo já utilizado", "Este e-mail ou username já está sendo utilizado.");
        return BadRequest(ModelState);
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
