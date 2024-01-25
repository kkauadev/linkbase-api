using AutoMapper;
using LinkBaseApi.Application.DTOs.Folder;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Folders.GetAllFolders
{
	public class GetAllFoldersHandler(IFolderRepository folderRepository, IMapper mapper) 
		: IRequestHandler<GetAllFoldersRequest, Response<List<FolderResponseWithLinks>>>
	{
		private readonly IFolderRepository _folderRepository = folderRepository;
		private readonly IMapper _mapper = mapper;

		public async Task<Response<List<FolderResponseWithLinks>>> Handle(GetAllFoldersRequest request, CancellationToken cancellationToken)
		{
			var folders = await _folderRepository.GetAll(cancellationToken);

			var result = _mapper.Map<List<FolderResponseWithLinks>>(folders);

			return new Response<List<FolderResponseWithLinks>>(result);
		}
	}
}
