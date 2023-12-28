namespace linkbase_api.Models
{
  public class Folder
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }
    public ICollection<Link>? Links { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastUpdated { get; set; }
  }
}
