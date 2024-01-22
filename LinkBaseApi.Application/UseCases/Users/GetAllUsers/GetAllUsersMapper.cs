using AutoMapper;
using LinkBaseApi.Application.DTOs;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Application.UseCases.Users.GetAllUsers
{
    public class GetAllUsersMapper : Profile
	{
        public GetAllUsersMapper()
        {
            CreateMap<User, UserResponseWithFolders>();
        }
    }
}