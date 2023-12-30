namespace LinkBaseApi.Models
{
  public class Link
  {
    public Guid Id { get; set; }
    public Guid FolderId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastUpdated { get; set; }
  }
}
