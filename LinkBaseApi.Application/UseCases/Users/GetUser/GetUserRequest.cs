using LinkBaseApi.Application.DTOs;
using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Users.GetUser
{
    public record GetUserRequest : IRequest<Response<UserResponse>>
	{
		public Guid Id { get; set; }
	}
}
