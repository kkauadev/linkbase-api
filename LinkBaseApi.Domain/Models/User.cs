using LinkBaseApi.Domain.Common;

namespace LinkBaseApi.Domain.Models
{
    public sealed class User : BaseEntity
    {
        public required string Username { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? Bio { get; set; }
        public required ICollection<Folder> Folders { get; set; }
    }
}
