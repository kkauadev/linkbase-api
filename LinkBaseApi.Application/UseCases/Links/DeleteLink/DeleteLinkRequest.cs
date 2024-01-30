using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Links.DeleteLink
{
	public class DeleteLinkRequest : IRequest<Response<Guid>>
	{
		public Guid Id { get; set; }
	}
}
