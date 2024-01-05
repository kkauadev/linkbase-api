using LinkBaseApi.Persistence.DTOs.User;

namespace LinkBaseApi.Application.UseCases.Users.CreateUser
{
    public record CreateUserResponse
    {
        public required Guid Id { get; set; }
        public required string Username { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required ICollection<UserDTOFolders> Folders { get; set; }
        public string? Bio { get; set; }
    }
}
