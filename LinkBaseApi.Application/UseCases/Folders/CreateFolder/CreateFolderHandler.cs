using AutoMapper;
using LinkBaseApi.Application.DTOs;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Domain.Models;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Folders.CreateFolder
{
	public class CreateFolderHandler(IUnitOfWork unitOfWork, IFolderRepository folderRepository, IMapper mapper) : IRequestHandler<CreateFolderRequest, Response<CreateFolderResponse>>
	{
		private readonly IUnitOfWork _unitOfWork = unitOfWork;
		private readonly IFolderRepository _folderRepository = folderRepository;
		private readonly IMapper _mapper = mapper;
		public async Task<Response<CreateFolderResponse>> Handle(CreateFolderRequest request, CancellationToken cancellationToken)
		{
			var folder = _mapper.Map<Folder>(request);

			_folderRepository.Create(folder);

			await _unitOfWork.Commit(cancellationToken);

			var response = _mapper.Map<CreateFolderResponse>(folder);

			return new Response<CreateFolderResponse>(response);
		}
	}
}
