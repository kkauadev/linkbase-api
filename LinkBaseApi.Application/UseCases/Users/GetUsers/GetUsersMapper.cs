using AutoMapper;
using LinkBaseApi.Application.UseCases.Users.GetUsers;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Application.UseCases.Users.GetAllUsers
{
    public class GetUsersMapper : Profile
	{
        public GetUsersMapper()
        {
            CreateMap<User, GetUsersResponse>();
        }
    }
}