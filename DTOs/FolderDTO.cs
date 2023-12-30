namespace LinkBaseApi.DTOs
{
  public class FolderDTO
  {
    public required string Name { get; set; }
    public string? Description { get; set; }
  }

  public class FolderDTOUpdate
  {
    public string? Name { get; set; }
    public string? Description { get; set; }
  }
}
