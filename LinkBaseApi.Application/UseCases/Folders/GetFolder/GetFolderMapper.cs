using AutoMapper;
using LinkBaseApi.Application.DTOs;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Application.UseCases.Folders.GetFolder
{
	public class GetFolderMapper : Profile
	{
		public GetFolderMapper()
		{
			CreateMap<Folder, FolderResponse>();
		}
	}
}
