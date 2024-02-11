using AutoMapper;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces.Model;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Folders.GetAllFolders
{
    public class GetAllFoldersHandler(IFolderRepository folderRepository, IMapper mapper) 
		: IRequestHandler<GetAllFoldersRequest, Response<List<GetAllFoldersResponse>>>
	{
		private readonly IFolderRepository _folderRepository = folderRepository;
		private readonly IMapper _mapper = mapper;

		public async Task<Response<List<GetAllFoldersResponse>>> Handle(GetAllFoldersRequest request, CancellationToken cancellationToken)
		{
			var folders = await _folderRepository.GetAll(cancellationToken);

			var result = _mapper.Map<List<GetAllFoldersResponse>>(folders);

			return new Response<List<GetAllFoldersResponse>>(result);
		}
	}
}
