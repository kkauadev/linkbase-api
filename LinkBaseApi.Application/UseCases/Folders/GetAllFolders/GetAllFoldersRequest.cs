using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Folders.GetAllFolders
{
	public record GetAllFoldersRequest : IRequest<Response<List<GetAllFoldersResponse>>>;
}
