using LinkBaseApi.Application.DTOs.User;
using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Users.GetAllUsers
{
    public record GetAllUsersRequest : IRequest<Response<List<UserResponseWithFolders>>>;
}
