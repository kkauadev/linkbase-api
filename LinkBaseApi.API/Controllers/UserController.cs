using Microsoft.AspNetCore.Mvc;
using MediatR;
using LinkBaseApi.Application.UseCases.Users.CreateUser;
using LinkBaseApi.Application.UseCases.Users.GetAllUsers;
using LinkBaseApi.Application.UseCases.Users.UpdateUser;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Application.UseCases.Users.GetUser;
using LinkBaseApi.Application.UseCases.Users.DeleteUser;
using LinkBaseApi.Application.DTOs;
using LinkBaseApi.Application.DTOs.User;
using LinkBaseApi.Infrastructure.Context;

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
        public async Task<ActionResult<Response<UserResponse>>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(new GetUserRequest { Id = id }, cancellationToken);

            return Ok(user);
        }

        [HttpPost("/user")]
        public async Task<ActionResult<Response<Guid>>> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        [HttpPut("/user/{id}")]
        public async Task<ActionResult<Response<UserResponse>>> UpdateById(Guid id, [FromBody] string? name, [FromBody] string? bio, CancellationToken cancellationToken)
        {
			UpdateUserRequest request = new()
            {
                Bio = bio,
                Name = name,
                Id = id,
            };

            var response = await _mediator.Send(request, cancellationToken);
 
            return Ok(response);
        }

        [HttpDelete("/user/{id}")]
        public async Task<ActionResult<Response<Guid>>> DeleteById(Guid id, CancellationToken cancellationToken)
        {
			var response = await _mediator.Send(new DeleteUserRequest { Id = id }, cancellationToken);

            return Ok(response);
        }
    }
}
