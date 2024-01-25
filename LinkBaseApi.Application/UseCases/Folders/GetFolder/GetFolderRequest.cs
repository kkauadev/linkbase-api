using LinkBaseApi.Application.DTOs;
using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Folders.GetFolder
{
	public class GetFolderRequest : IRequest<Response<FolderResponse>>
	{
		public Guid Id { get; set; }
	}
}
