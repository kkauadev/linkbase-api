namespace LinkBaseApi.DTOs
{
	public class CreateLinkDTO
	{
		public required string Title { get; set; }
		public required string Url { get; set; }
		public string? Description { get; set; }
	}
}