namespace LinkBaseApi.DTOs
{
	public record TokenGenerationRequest
	{
		public Guid UserId { get; set; }
		public required string Email { get; set; }
	}
}
