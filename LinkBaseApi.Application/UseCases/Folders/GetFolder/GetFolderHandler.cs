using AutoMapper;
using LinkBaseApi.Application.Exceptions;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces.Model;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Folders.GetFolder
{
    public class GetFolderHandler(IFolderRepository folderRepository, IMapper mapper) : IRequestHandler<GetFolderRequest, Response<GetFolderResponse>>
	{
		private readonly IFolderRepository _folderRepository = folderRepository;
		private readonly IMapper _mapper = mapper;
		public async Task<Response<GetFolderResponse>> Handle(GetFolderRequest request, CancellationToken cancellationToken)
		{
			var user = await _folderRepository.Get(request.Id, cancellationToken) ?? throw new ApiException();

			var response  = _mapper.Map<GetFolderResponse>(user);

			return new Response<GetFolderResponse>(response);
		}
	}
}
