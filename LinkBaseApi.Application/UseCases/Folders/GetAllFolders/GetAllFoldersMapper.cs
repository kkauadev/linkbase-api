using AutoMapper;
using LinkBaseApi.Application.DTOs.Folder;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Application.UseCases.Folders.GetAllFolders
{
	public class GetAllFoldersMapper : Profile
	{
		public GetAllFoldersMapper()
		{
			CreateMap<Folder, FolderResponseWithLinks>();
		}
	}
}
