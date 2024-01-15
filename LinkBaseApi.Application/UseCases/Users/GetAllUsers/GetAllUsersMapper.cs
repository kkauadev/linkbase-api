using AutoMapper;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Application.UseCases.Users.GetAllUsers
{
	public class GetAllUsersMapper : Profile
	{
        public GetAllUsersMapper()
        {
            CreateMap<User, UserResponse>();
        }
    }
}