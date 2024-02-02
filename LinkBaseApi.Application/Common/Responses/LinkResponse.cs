namespace LinkBaseApi.Application.Common.Responses
{
    public record LinkResponse
    {
        public required Guid Id { get; set; }
        public required Guid FolderId { get; set; }
        public required string Title { get; set; }
        public required string Url { get; set; }
        public string? Description { get; set; }
    }
}
