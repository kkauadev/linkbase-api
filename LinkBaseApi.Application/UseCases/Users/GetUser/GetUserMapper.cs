using AutoMapper;
using LinkBaseApi.Application.UseCases.Users.GetUser;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.LinkBaseApi.Application.UseCases.Users.GetUser
{
    public class GetUserMapper : Profile
	{
        public GetUserMapper()
        {
            CreateMap<User, GetUserResponse>();
        }
    }
}
