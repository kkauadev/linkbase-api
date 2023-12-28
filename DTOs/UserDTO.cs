using linkbase_api.Models;
using System.ComponentModel.DataAnnotations;

namespace linkbase_api.DTOs
{
  public class UserDTO
  {
    public required string Username { get; set; }
    public required string Name { get; set; }
    [EmailAddress()]
    public required string Email { get; set; }
    [MinLength(8)]
    public required string Password { get; set; }
    public string? Bio { get; set; }
    public ICollection<Folder>? Folders { get; set; }
  }

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
}
