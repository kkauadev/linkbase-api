using AutoMapper;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Application.UseCases.Folders.UpdateFolder
{
	public class UpdateFolderMapper : Profile
	{
        public UpdateFolderMapper()
        {
            CreateMap<UpdateFolderRequest, Folder>();
            CreateMap<Folder, UpdateFolderResponse>();
        }
    }
}
