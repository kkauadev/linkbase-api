using AutoMapper;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.LinkBaseApi.Application.UseCases.Users.DeleteUser
{
	public class DeleteUserMapper : Profile
	{
        public DeleteUserMapper()
        {
            CreateMap<DeleteUserRequest, DeleteUserResponse>();
        }
    }
}
