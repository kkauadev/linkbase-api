using AutoMapper;
using LinkBaseApi.Application.DTOs;
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
