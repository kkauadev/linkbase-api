using LinkBaseApi.Application.DTOs.Folder;
using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Folders.GetAllFolders
{
	public record GetAllFoldersRequest : IRequest<Response<List<FolderResponseWithLinks>>>;
}
