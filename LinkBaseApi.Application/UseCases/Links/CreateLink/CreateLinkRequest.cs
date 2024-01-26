using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Links.CreateLink
{
	public class CreateLinkRequest : IRequest<Response<CreateLinkResponse>>
	{
		public required Guid FolderId { get; set; }
		public required string Title { get; set; }
		public string? Description { get; set; }
		public required string Url { get; set; }
	}
}
