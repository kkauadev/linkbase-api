using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Models;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Folders.CreateFolder
{
    public record CreateFolderRequest : IRequest<Response<CreateFolderResponse>>
	{
		public required Guid UserId { get; set; }
		public required string Name { get; set; }
		public string? Description { get; set; }
		public required ICollection<Link> Links { get; set; }
	}
}
