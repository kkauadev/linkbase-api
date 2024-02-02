using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Links.DeleteLink
{
	public class DeleteLinkRequest : IRequest<Response<DeleteLinkResponse>>
	{
		public Guid Id { get; set; }
	}
}
