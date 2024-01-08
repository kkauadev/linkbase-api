namespace LinkBaseApi.Domain.DTOs
{
    public class FolderDTO
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }

    public class FolderViewDTO
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<LinkDTOView>? Links { get; set; }
    }

    public class FolderDTOUpdate
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
