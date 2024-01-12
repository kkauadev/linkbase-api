using MediatR;

namespace LinkBaseApi.LinkBaseApi.Application.UseCases.Users.GetUser
{
	public record GetUserRequest : IRequest<GetUserResponse>
	{
        public Guid Id { get; set; }
    }
}
