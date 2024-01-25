using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Application.DTOs
{
	public class FolderResponse
	{
        public required Guid Id { get; set; }
        public required Guid UserId { get; set; }
		public required string Name { get; set; }
		public string? Description { get; set; }
	}
}
