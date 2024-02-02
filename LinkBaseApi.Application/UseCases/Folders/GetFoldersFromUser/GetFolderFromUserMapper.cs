using AutoMapper;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Application.UseCases.Folders.GetFoldersFromUser
{
	public class GetFolderFromUserMapper : Profile
	{
        public GetFolderFromUserMapper()
        {
            CreateMap<Folder, GetFoldersFromUserResponse>();
        }
    }
}
