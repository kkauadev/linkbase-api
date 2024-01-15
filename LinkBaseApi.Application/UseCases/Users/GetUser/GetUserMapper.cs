using AutoMapper;
using LinkBaseApi.Application.UseCases.Users;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.LinkBaseApi.Application.UseCases.Users.GetUser
{
	public class GetUserMapper : Profile
	{
        public GetUserMapper()
        {
            CreateMap<User, UserResponse>();
        }
    }
}
