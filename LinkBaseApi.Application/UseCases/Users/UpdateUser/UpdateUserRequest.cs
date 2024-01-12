using LinkBaseApi.Domain.DTOs.User;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Users.UpdateUser
{
	public record UpdateUserRequest : IRequest<UpdateUserResponse>
	{
		public string? Name { get; set; }
		public string? Bio { get; set; }
	}
}
