using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Folders.GetFolder
{
	public class GetFolderRequest : IRequest<Response<GetFolderResponse>>
	{
		public Guid Id { get; set; }
	}
}
