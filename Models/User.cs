

namespace linkbase_api.Models
{
  public class User
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Username { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? Bio { get; set; }
    public ICollection<Folder>? Folders { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? LastUpdated { get; set; }
  }
}
