using LinkBaseApi.Application.Exceptions;
using LinkBaseApi.Application.UseCases.Users.CreateUser;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LinkBaseApi.Controllers
{
	public class IdentityController(IAuthenticationService authenticationService, IMediator mediator) : ControllerBase
	{
		private readonly IAuthenticationService _authenticationService = authenticationService;
		private readonly IMediator _mediator = mediator;

		[HttpPost("login")]
		public async Task<ActionResult<Response<UserTokenResponse>>> LoginUser([FromBody] LoginRequest loginRequest, CancellationToken cancellationToken)
		{
			var id = await _authenticationService.ValidateCredentials(loginRequest.Username, loginRequest.Password, cancellationToken) 
				?? throw new UnauthorizedException("Invalid credentials. Check your username and password.");
			
			var token = _authenticationService.GenerateToken(id, loginRequest.Username);

			var userTokenResponse = new UserTokenResponse
			{
				Id = id,
				Token = token,
			};

			var response = new Response<UserTokenResponse>(userTokenResponse);

			return Ok(response);
		}

		[HttpPost("register")]
		public async Task<ActionResult<Response<UserTokenResponse>>> RegisterUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
		{
			var userCreated = await _mediator.Send(request, cancellationToken) ?? throw new ApiException(
				"The request could not be processed. Please check the data provided.");

			if (userCreated.Data?.Id is null) { return Unauthorized(); }

			var token = _authenticationService.GenerateToken(userCreated.Data.Id, request.Username) ?? throw new ApiException(
				"The request could not be processed. Please check the data provided.");

			var userTokenResponse = new UserTokenResponse
			{
				Id = userCreated.Data.Id,
				Token = token,
			};

			var response = new Response<UserTokenResponse>(userTokenResponse);

			return Ok(response);
		}
	}
}
