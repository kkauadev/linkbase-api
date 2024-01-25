using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Folders.DeleteFolder
{
	public record DeleteFolderRequest : IRequest<Response<Guid>>
	{
		public Guid Id { get; set; }
	}
}
