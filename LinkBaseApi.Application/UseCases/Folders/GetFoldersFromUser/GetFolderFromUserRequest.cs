using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Folders.GetFoldersFromUser
{
	public class GetFolderFromUserRequest : IRequest<Response<List<GetFoldersFromUserResponse>>>
	{
		public Guid UserId { get; set; }
	}
}
