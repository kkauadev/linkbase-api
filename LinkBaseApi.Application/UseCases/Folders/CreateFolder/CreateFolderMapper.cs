using AutoMapper;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Application.UseCases.Folders.CreateFolder
{
    public class CreateFolderMapper : Profile
	{
		public CreateFolderMapper()
		{
			CreateMap<CreateFolderRequest, Folder>();
			CreateMap<Folder, CreateFolderResponse>();
		}
	}
}
