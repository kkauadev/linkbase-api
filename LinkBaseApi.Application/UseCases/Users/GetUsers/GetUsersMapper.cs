using AutoMapper;
using LinkBaseApi.Application.DTOs.User;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Application.UseCases.Users.GetAllUsers
{
    public class GetUsersMapper : Profile
	{
        public GetUsersMapper()
        {
            CreateMap<User, UserResponseWithFolders>();
        }
    }
}