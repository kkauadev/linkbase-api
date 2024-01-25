using AutoMapper;
using LinkBaseApi.Application.DTOs.Folder;
using LinkBaseApi.Application.Exceptions;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Folders.GetFoldersFromUser
{
	public class GetFolderFromUserHandler(IFolderRepository folderRepository, IMapper mapper) : IRequestHandler<GetFolderFromUserRequest, Response<List<FolderResponseWithLinks>>>
	{
		private readonly IFolderRepository _folderRepository = folderRepository;
		private readonly IMapper _mapper = mapper;
		public async Task<Response<List<FolderResponseWithLinks>>> Handle(GetFolderFromUserRequest request, CancellationToken cancellationToken)
		{
			var folders = await _folderRepository.GetByAuthor(request.UserId, cancellationToken) ?? throw new ApiException();

			var response = _mapper.Map<List<FolderResponseWithLinks>>(folders);

			return new Response<List<FolderResponseWithLinks>>(response);
		}
	}
}
