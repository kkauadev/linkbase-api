using AutoMapper;
using LinkBaseApi.Application.DTOs;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Domain.Models;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Links.GetLinkByFolder;

public class GetLinkByFolderHandler(ILinkRepository linkRepository, IMapper mapper)
			: IRequestHandler<GetLinkByFolderRequest, Response<List<LinkResponse>>>
{
	private readonly ILinkRepository _linkRepository = linkRepository;
	private readonly IMapper _mapper = mapper;

	public async Task<Response<List<LinkResponse>>> Handle(GetLinkByFolderRequest request, CancellationToken cancellationToken)
	{
		List<Link> links = await _linkRepository.GetByFolderId(request.FolderId, cancellationToken);

		var result = _mapper.Map<List<LinkResponse>>(links);

		return new Response<List<LinkResponse>>(result);
	}
}