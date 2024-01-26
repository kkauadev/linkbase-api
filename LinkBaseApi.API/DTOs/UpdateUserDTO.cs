namespace LinkBaseApi.DTOs
{
	public record UpdateUserDTO
	{
		public string? Bio { get; set; }
		public string? Name { get; set; }
	}
}