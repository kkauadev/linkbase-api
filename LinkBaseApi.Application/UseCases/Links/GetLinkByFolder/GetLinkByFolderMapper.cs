using AutoMapper;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Application.UseCases.Links.GetLinkByFolder
{
	public class GetLinkByFolderMapper : Profile
	{
        public GetLinkByFolderMapper()
        {
            CreateMap<Link, GetLinkByFolderResponse>();
        }
    }
}
