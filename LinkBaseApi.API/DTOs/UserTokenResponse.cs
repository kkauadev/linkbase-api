namespace LinkBaseApi.DTOs
{
	public record UserTokenResponse
	{
        public required string Token { get; set; }
        public required Guid Id { get; set; }
    }
}
