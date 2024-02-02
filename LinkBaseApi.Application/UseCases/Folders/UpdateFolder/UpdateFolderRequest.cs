using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Folders.UpdateFolder
{
	public class UpdateFolderRequest : IRequest<Response<UpdateFolderResponse>>
	{
		public Guid Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
	}
}
