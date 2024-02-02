namespace LinkBaseApi.Application.UseCases.Links.CreateLink
{
	public record CreateLinkResponse
	{
		public Guid Id { get; set; }
		public Guid FolderId { get; set; }
	}
}
