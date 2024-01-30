using AutoMapper;
using LinkBaseApi.Application.DTOs;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Links.GetAllLinks
{
    public class GetLinksHandler(ILinkRepository linkRepository, IMapper mapper)
				: IRequestHandler<GetLinksRequest, Response<List<LinkResponse>>>
	{
		private readonly ILinkRepository _linkRepository = linkRepository;
		private readonly IMapper _mapper = mapper;

		async Task<Response<List<LinkResponse>>> IRequestHandler<GetLinksRequest, Response<List<LinkResponse>>>.Handle(GetLinksRequest request, CancellationToken cancellationToken)
		{
			var links = await _linkRepository.GetAll(cancellationToken);

			var result = _mapper.Map<List<LinkResponse>>(links);

			return new Response<List<LinkResponse>>(result);
		}
	}
}