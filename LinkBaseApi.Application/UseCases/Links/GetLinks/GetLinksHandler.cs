using AutoMapper;
using LinkBaseApi.Application.UseCases.Links.GetLinks;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces.Model;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Links.GetAllLinks
{
    public class GetLinksHandler(ILinkRepository linkRepository, IMapper mapper)
				: IRequestHandler<GetLinksRequest, Response<List<GetLinksResponse>>>
	{
		private readonly ILinkRepository _linkRepository = linkRepository;
		private readonly IMapper _mapper = mapper;

		public async Task<Response<List<GetLinksResponse>>> Handle(GetLinksRequest request, CancellationToken cancellationToken)
		{
			var links = await _linkRepository.GetAll(cancellationToken);

			var result = _mapper.Map<List<GetLinksResponse>>(links);

			return new Response<List<GetLinksResponse>>(result);
		}

	}
}