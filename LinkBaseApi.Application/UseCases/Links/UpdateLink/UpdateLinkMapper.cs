using AutoMapper;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Application.UseCases.Links.UpdateLink
{
	public class UpdateLinkMapper : Profile
	{
        public UpdateLinkMapper()
        {
            CreateMap<UpdateLinkRequest, Link>();
            CreateMap<Link, UpdateLinkResponse>();
        }
    }
}
