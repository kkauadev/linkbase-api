namespace LinkBaseApi.Models
{
  public class Link
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid FolderId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required string Url { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastUpdated { get; set; }
  }
}
