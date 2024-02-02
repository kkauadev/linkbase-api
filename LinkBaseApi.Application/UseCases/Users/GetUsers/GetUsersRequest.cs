using LinkBaseApi.Application.UseCases.Users.GetUsers;
using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Users.GetAllUsers
{
	public record GetUsersRequest : IRequest<Response<List<GetUsersResponse>>>;
}
