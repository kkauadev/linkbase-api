using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Users.UpdateUser
{
	public record UpdateUserRequest : IRequest<Response<UpdateUserResponse>>
	{
		public Guid Id { get; set; }
		public string? Name { get; set; }
		public string? Bio { get; set; }
	}
}
