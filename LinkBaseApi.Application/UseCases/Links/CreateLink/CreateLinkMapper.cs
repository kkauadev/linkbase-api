using AutoMapper;
using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Application.UseCases.Links.CreateLink
{
	public class CreateLinkMapper : Profile
	{
		public CreateLinkMapper() 
		{
			CreateMap<CreateLinkRequest, Link>();
			CreateMap<Link, CreateLinkResponse>();
		}
	}
}
