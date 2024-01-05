using System.ComponentModel.DataAnnotations;

namespace LinkBaseApi.Persistence.DTOs.User
{
    public class UserUpdateDTO
    {
        public string? Username { get; set; }
        public string? Name { get; set; }
        [EmailAddress()]
        public string? Email { get; set; }
        [MinLength(8)]
        public string? Password { get; set; }
        public string? Bio { get; set; }
    }

    public class UserUpdateBioViewDTO
    {
        public required string Username { get; set; }
        public required string Bio { get; set; }
    }
}
