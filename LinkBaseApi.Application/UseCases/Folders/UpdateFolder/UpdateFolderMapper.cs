using AutoMapper;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Application.UseCases.Folders.UpdateFolder
{
	public class UpdateFolderMapper : Profile
	{
        public UpdateFolderMapper()
        {
            CreateMap<Folder, UpdateFolderResponse>();
        }
    }
}
