using AutoMapper;
using LinkBaseApi.Application.DTOs;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Application.UseCases.Links.GetLinkByFolder
{
	public class GetLinkByFolderMapper : Profile
	{
        public GetLinkByFolderMapper()
        {
            CreateMap<Link, LinkResponse>();
        }
    }
}
