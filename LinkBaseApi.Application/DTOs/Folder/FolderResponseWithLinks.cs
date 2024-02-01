using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Application.DTOs.Folder
{
	public class FolderResponseWithLinks : FolderResponse
	{
		public required List<Link> Links { get; set; }
	}
}
