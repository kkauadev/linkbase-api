using LinkBaseApi.Application.Common.Responses;

namespace LinkBaseApi.Application.UseCases.Folders.GetFolder
{
	public record GetFolderResponse : FolderResponse
	{
		public required List<LinkResponse> Links { get; set; }
	}
}
