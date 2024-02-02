namespace LinkBaseApi.Application.UseCases.Folders.CreateFolder
{
    public record CreateFolderResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
