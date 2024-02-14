using AutoMapper;
using LinkBaseApi.Application.Common.Responses;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Application.UseCases.Folders.GetFolder
{
	public class GetFolderMapper : Profile
	{
		public GetFolderMapper()
		{
			CreateMap<Folder, GetFolderResponse>()
				.ForMember(dest => dest.Links, opt => opt.MapFrom(src => src.Links));
			CreateMap<Link, LinkResponse>();
		}
	}
}
