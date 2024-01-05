using LinkBaseApi.Domain.Common;

namespace LinkBaseApi.Domain.Models
{
    public sealed class Link : BaseEntity
    {
        public Guid FolderId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required string Url { get; set; }
    }
}
