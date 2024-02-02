using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Links.GetLinkByFolder
{
	public record GetLinkByFolderRequest : IRequest<Response<List<GetLinkByFolderResponse>>>
	{
		public required Guid FolderId { get; set; }
	}
}
