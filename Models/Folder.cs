namespace LinkBaseApi.Models
{
  public class Folder
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public required Guid UserId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required ICollection<Link> Links { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? LastUpdated { get; set; }
  }
}
