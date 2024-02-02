using AutoMapper;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Application.UseCases.Folders.GetAllFolders
{
	public class GetAllFoldersMapper : Profile
	{
		public GetAllFoldersMapper()
		{
			CreateMap<Folder, GetAllFoldersResponse>();
		}
	}
}
