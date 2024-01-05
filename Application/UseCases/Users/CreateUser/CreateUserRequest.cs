using LinkBaseApi.Persistence.DTOs.User;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LinkBaseApi.Application.UseCases.Users.CreateUser
{
    public record CreateUserRequest : IRequest<CreateUserResponse>
    {
        public required string Username { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? Bio { get; set; }
        public ICollection<UserDTOFolders>? Folders { get; set; }
    }
}

