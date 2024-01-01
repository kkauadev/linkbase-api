namespace LinkBaseApi.DTOs
{
  public class LinkDTO
  {
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required string Url { get; set; }
  }
  public class LinkDTOView : LinkDTO
  {
    public required Guid Id { get; set; }
  }
}
