using LinkBaseApi.Application.DTOs.Folder;
using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Folders.GetFoldersFromUser
{
	public class GetFolderFromUserRequest : IRequest<Response<List<FolderResponseWithLinks>>>
	{
		public Guid UserId { get; set; }
	}
}
