namespace LinkBaseApi.Application.DTOs
{
    public record UserResponse
    {
        public required Guid Id { get; set; }
        public required string Username { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Bio { get; set; }
    }
}
