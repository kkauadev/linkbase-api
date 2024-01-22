using Microsoft.AspNetCore.Mvc;
using MediatR;
using LinkBaseApi.Persistence.Context;
using LinkBaseApi.Domain.Models;
using LinkBaseApi.Application.UseCases.Users.CreateUser;
using LinkBaseApi.Application.UseCases.Users.GetAllUsers;
using LinkBaseApi.Application.UseCases.Users.UpdateUser;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Application.UseCases.Users.GetUser;
using LinkBaseApi.Application.UseCases.Users.DeleteUser;
using LinkBaseApi.Application.DTOs;

namespace LinkBaseApi.Controllers
{
    public class UserController(ILogger<UserController> logger, DataContext dataContext, IMediator mediator) : ControllerBase
    {
        public readonly ILogger<UserController> _logger = logger;
        public readonly DataContext _dataContext = dataContext;
        public readonly IMediator _mediator = mediator;

        [HttpGet("/users")]
        public async Task<ActionResult<List<UserResponseWithFolders>>> GetAll()
        {
            Response<List<UserResponseWithFolders>> response = await _mediator.Send(new GetAllUsersRequest());

			return Ok(response);
        }

        [HttpGet("/user/{id}")]
        public async Task<ActionResult<UserResponse>> GetById(Guid id, CancellationToken cancellationToken)
        {
            GetUserRequest getUserRequest = new() { Id = id };

            var user = await _mediator.Send(getUserRequest, cancellationToken);

            return Ok(user);
        }

		[HttpPost("/user")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
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

        [HttpDelete("/user/{id}")]
        public async Task<ActionResult<Guid>> DeleteById(Guid id, CancellationToken cancellationToken)
        {
			DeleteUserRequest deleteUserRequest = new() { Id = id };
			var response = await _mediator.Send(deleteUserRequest, cancellationToken);

            return Ok($"Usuário {response} removido");
        }
    }
}
