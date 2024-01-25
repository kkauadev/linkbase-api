namespace LinkBaseApi.Application.DTOs.User
{
    public record UserResponseWithFolders : UserResponse
    {
		public required ICollection<FolderResponse> Folders { get; set; }
	}
}
