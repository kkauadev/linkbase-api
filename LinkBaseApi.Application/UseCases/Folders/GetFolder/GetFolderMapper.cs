using AutoMapper;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Application.UseCases.Folders.GetFolder
{
	public class GetFolderMapper : Profile
	{
		public GetFolderMapper()
		{
			CreateMap<Folder, GetFolderResponse>();
		}
	}
}
