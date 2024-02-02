using Microsoft.AspNetCore.Mvc;
using MediatR;
using LinkBaseApi.Application.UseCases.Users.CreateUser;
using LinkBaseApi.Application.UseCases.Users.GetAllUsers;
using LinkBaseApi.Application.UseCases.Users.UpdateUser;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Application.UseCases.Users.GetUser;
using LinkBaseApi.Application.UseCases.Users.DeleteUser;
using LinkBaseApi.DTOs;
using LinkBaseApi.Application.UseCases.Users.GetUsers;

namespace LinkBaseApi.Controllers
{
	public class UserController(ILogger<UserController> logger, IMediator mediator) : ControllerBase
    {
        public readonly ILogger<UserController> _logger = logger;
        public readonly IMediator _mediator = mediator;

        [HttpGet("/users")]
        public async Task<ActionResult<Response<List<GetUsersResponse>>>> GetAll()
        {
            var response = await _mediator.Send(new GetUsersRequest());

            return Ok(response);
        }

        [HttpGet("/user/{id}")]
        public async Task<ActionResult<Response<GetUserResponse>>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetUserRequest { Id = id }, cancellationToken);

            return Ok(response);
        }

        [HttpPost("/user")]
        public async Task<ActionResult<Response<CreateUserResponse>>> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        [HttpPut("/user/{id}")]
        public async Task<ActionResult<Response<UpdateUserResponse>>> UpdateById(Guid id, [FromBody] UpdateUserDTO updateUserDTO, CancellationToken cancellationToken)
        {
			UpdateUserRequest request = new()
            {
                Bio = updateUserDTO.Bio,
                Name = updateUserDTO.Name,
                Id = id,
            };

            var response = await _mediator.Send(request, cancellationToken);
 
            return Ok(response);
        }

        [HttpDelete("/user/{id}")]
        public async Task<ActionResult<Response<DeleteUserResponse>>> DeleteById(Guid id, CancellationToken cancellationToken)
        {
			var response = await _mediator.Send(new DeleteUserRequest { Id = id }, cancellationToken);

            return Ok(response);
        }
    }
}
