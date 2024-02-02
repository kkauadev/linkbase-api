using LinkBaseApi.Application.Exceptions;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Folders.DeleteFolder
{
	public class DeleteFolderHandler(IUnitOfWork unitOfWork, IFolderRepository folderRepository)
		: IRequestHandler<DeleteFolderRequest, Response<DeleteFolderResponse>>
	{
		private readonly IUnitOfWork _unitOfWork = unitOfWork;
		private readonly IFolderRepository _folderRepository = folderRepository;

		public async Task<Response<DeleteFolderResponse>> Handle(DeleteFolderRequest request, CancellationToken cancellationToken)
		{
			var userExists = await _folderRepository.Get(request.Id, cancellationToken)
				?? throw new ApiException("Folder not found.");

			_folderRepository.Delete(userExists);

			await _unitOfWork.Commit(cancellationToken);

			return new Response<DeleteFolderResponse>(new DeleteFolderResponse() { Id = request.Id });
		}
	}
}