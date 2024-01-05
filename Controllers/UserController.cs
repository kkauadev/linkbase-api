using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LinkBaseApi.Domain.Models;
using LinkBaseApi.Persistence.DTOs.User;
using LinkBaseApi.Persistence.Context;
using LinkBaseApi.Application.Services;
using LinkBaseApi.Application.Helpers;
using MediatR;
using LinkBaseApi.Application.UseCases.Users.CreateUser;

namespace LinkBaseApi.Controllers
{
    public class UserController(ILogger<UserController> logger, DataContext dataContext, ValidationService validationService, IMediator mediator) : ControllerBase
    {
        public readonly ILogger<UserController> _logger = logger;
        public readonly DataContext _dataContext = dataContext;
        public readonly ValidationService _validationService = validationService;
        public readonly IMediator _mediator = mediator;

        [HttpGet("/users")]
        public async Task<ActionResult<List<UserViewDTO>>> GetAll()
        {
            List<UserViewDTO>? users = await _dataContext.Users
              .Include(u => u.Folders)
              .Select(u => new UserViewDTO()
              {
                  Email = u.Email,
                  Id = u.Id,
                  Name = u.Name,
                  Username = u.Username,
                  Bio = u.Bio,
                  Folders = u.Folders.Select(f => new UserDTOFolders()
                  {
                      Id = f.Id,
                      Name = f.Name,
                      Description = f.Description
                  }).ToList()
              })
              .ToListAsync();

            return users;
        }

        [HttpGet("/user/{id}")]
        public async Task<ActionResult<UserViewDTO>> GetUserById(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
            {
                return BadRequest("Insira um id válido");
            }

            User? user = await _dataContext
              .Users
              .Include(u => u.Folders)
              .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return NotFound("O usuário não existe");
            }

            UserViewDTO userView = new()
            {
                Bio = user.Bio,
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Folders = user.Folders.Select(f => new UserDTOFolders()
                {
                    Id = f.Id,
                    Name = f.Name,
                    Description = f.Description
                }).ToList()
            };

            return Ok(userView);
        }

        [HttpPost("/user")]
        public async Task<ActionResult<User>> Post([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
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

            UserUpdateBioViewDTO userUpdateBioViewDTO = new()
            {
                Bio = user.Bio,
                Username = user.Username
            };

            return Ok(userUpdateBioViewDTO);
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
