using LinkBaseApi.Domain.Common;

namespace LinkBaseApi.Domain.Models
{
    public sealed class Folder : BaseEntity
    {
        public required Guid UserId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required ICollection<Link> Links { get; set; }
    }
}
