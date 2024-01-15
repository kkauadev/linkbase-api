using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;
using LinkBaseApi.Persistence.Context;
using LinkBaseApi.Domain.DTOs.User;
using LinkBaseApi.Domain.Models;
using LinkBaseApi.Application.UseCases.Users.CreateUser;
using LinkBaseApi.Application.Helpers;
using LinkBaseApi.LinkBaseApi.Application.UseCases.Users.DeleteUser;
using LinkBaseApi.LinkBaseApi.Application.UseCases.Users.GetUser;
using LinkBaseApi.Application.UseCases.Users.GetAllUsers;
using LinkBaseApi.Application.UseCases.Users.UpdateUser;
using LinkBaseApi.Application.UseCases.Users;
using LinkBaseApi.Application.Wrappers;

namespace LinkBaseApi.Controllers
{
    public class UserController(ILogger<UserController> logger, DataContext dataContext, IMediator mediator) : ControllerBase
    {
        public readonly ILogger<UserController> _logger = logger;
        public readonly DataContext _dataContext = dataContext;
        public readonly IMediator _mediator = mediator;

        [HttpGet("/users")]
        public async Task<ActionResult<Response<List<UserResponse>>>> GetAll()
        {
            Response<List<UserResponse>> response = await _mediator.Send(new GetAllUsersRequest());


            return Ok(response);
        }

        [HttpGet("/user/{id}")]
        public async Task<ActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            GetUserRequest getUserRequest = new() { Id = id };

            var user = await _mediator.Send(getUserRequest, cancellationToken);

            return Ok(user);
        }

		[HttpPost("/user")]
        public async Task<ActionResult> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        [HttpPut("/user/{id}")]
        public async Task<ActionResult<User>> UpdateById([FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
 
            return Ok(response);
        }

        //[HttpPatch("/user/bio/{id}")]
        //public async Task<ActionResult> UpdateUserBio(string id, [FromBody] string bio)
        //{
        //    if (!Guid.TryParse(id, out Guid userId))
        //    {
        //        return BadRequest("Insira um ID válido");
        //    }
        //    if (string.IsNullOrEmpty(bio))
        //    {
        //        return BadRequest("A Bio não pode ser vazia");
        //    }
        //
        //    User? user = await _dataContext.Users.FindAsync(userId);
        //
        //    if (user == null)
        //    {
        //        return NotFound("Usuário não encontrado");
        //    }
        //
        //    user.Bio = bio;
        //
        //    _dataContext.Update(user);
        //    await _dataContext.SaveChangesAsync();
        //
        //    UserUpdateBioViewDTO userUpdateBioViewDTO = new()
        //    {
        //        Bio = user.Bio,
        //        Username = user.Username
        //    };
        //
        //    return Ok(userUpdateBioViewDTO);
        //}

        [HttpDelete("/user/{id}")]
        public async Task<ActionResult> DeleteById(Guid id, CancellationToken cancellationToken)
        {
			DeleteUserRequest deleteUserRequest = new() { Id = id };
			var response = await _mediator.Send(deleteUserRequest, cancellationToken);

            return Ok($"Usuário {response} removido");
        }
    }
}
