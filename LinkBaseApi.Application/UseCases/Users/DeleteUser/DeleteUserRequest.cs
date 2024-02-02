using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Users.DeleteUser
{
	public record DeleteUserRequest : IRequest<Response<DeleteUserResponse>>
	{
		public Guid Id { get; set; }
	}
}
