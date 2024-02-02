using AutoMapper;
using LinkBaseApi.Application.UseCases.Links.GetLinks;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Application.UseCases.Links.GetAllLinks
{
    public class GetLinksMapper : Profile
	{
        public GetLinksMapper()
        {
            CreateMap<Link, GetLinksResponse>();
        }
    }
}
