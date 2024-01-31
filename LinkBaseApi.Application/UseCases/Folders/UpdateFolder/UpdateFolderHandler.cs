using AutoMapper;
using LinkBaseApi.Application.DTOs;
using LinkBaseApi.Application.Exceptions;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Folders.UpdateFolder
{
	public class UpdateFolderHandler(IUnitOfWork unitOfWork, IFolderRepository folderRepository, IMapper mapper) : IRequestHandler<UpdateFolderRequest, Response<FolderResponse>>
	{
		private readonly IUnitOfWork _unitOfWork = unitOfWork;
		private readonly IFolderRepository _folderRepository = folderRepository;
		private readonly IMapper _mapper = mapper;
		public async Task<Response<FolderResponse>> Handle(UpdateFolderRequest request, CancellationToken cancellationToken)
		{
			var existingFolder = await _folderRepository.Get(request.Id, cancellationToken) ?? throw new ApiException("Folder Not Exists.");

			_mapper.Map(request, existingFolder);

			_folderRepository.Update(existingFolder);

			await _unitOfWork.Commit(cancellationToken);

			var response = _mapper.Map<FolderResponse>(existingFolder);

			return new Response<FolderResponse>(response);
		}
	}
}
