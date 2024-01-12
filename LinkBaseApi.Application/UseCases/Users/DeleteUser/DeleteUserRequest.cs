using MediatR;

namespace LinkBaseApi.LinkBaseApi.Application.UseCases.Users.DeleteUser
{
	public record DeleteUserRequest : IRequest<DeleteUserResponse>
	{
		public Guid Id { get; set; }
	}
}
