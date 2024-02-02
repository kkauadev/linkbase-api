using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Users.GetUser
{
    public record GetUserRequest : IRequest<Response<GetUserResponse>>
	{
		public Guid Id { get; set; }
	}
}
