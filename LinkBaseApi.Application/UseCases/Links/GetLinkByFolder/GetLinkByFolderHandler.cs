using AutoMapper;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces.Model;
using LinkBaseApi.Domain.Models;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Links.GetLinkByFolder;

public class GetLinkByFolderHandler(ILinkRepository linkRepository, IMapper mapper)
			: IRequestHandler<GetLinkByFolderRequest, Response<List<GetLinkByFolderResponse>>>
{
	private readonly ILinkRepository _linkRepository = linkRepository;
	private readonly IMapper _mapper = mapper;

	public async Task<Response<List<GetLinkByFolderResponse>>> Handle(GetLinkByFolderRequest request, CancellationToken cancellationToken)
	{
		List<Link> links = await _linkRepository.GetByFolderId(request.FolderId, cancellationToken);

		var result = _mapper.Map<List<GetLinkByFolderResponse>>(links);

		return new Response<List<GetLinkByFolderResponse>>(result);
	}
}