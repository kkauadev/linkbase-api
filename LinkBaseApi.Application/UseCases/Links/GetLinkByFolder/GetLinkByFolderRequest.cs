using LinkBaseApi.Application.DTOs;
using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Links.GetLinkByFolder
{
	public record GetLinkByFolderRequest : IRequest<Response<List<LinkResponse>>>
	{
		public required Guid FolderId { get; set; }
	}
}
