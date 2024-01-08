using System.ComponentModel.DataAnnotations;

namespace LinkBaseApi.Domain.DTOs.User
{
    public class UserDTOFolders
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
    public class UserDTO
    {
        public required string Username { get; set; }
        public required string Name { get; set; }
        [EmailAddress()]
        public required string Email { get; set; }
        [MinLength(8)]
        public required string Password { get; set; }
        public string? Bio { get; set; }
        public ICollection<UserDTOFolders>? Folders { get; set; }
    }

    public class UserViewDTO
    {
        public required Guid Id { get; set; }
        public required string Username { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required ICollection<UserDTOFolders> Folders { get; set; }
        public string? Bio { get; set; }
    }
}
