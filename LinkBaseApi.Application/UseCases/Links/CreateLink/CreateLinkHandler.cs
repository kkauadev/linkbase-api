using AutoMapper;
using LinkBaseApi.Application.Exceptions;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Domain.Models;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Links.CreateLink
{
	public class CreateLinkHandler(IUnitOfWork unitOfWork, ILinkRepository linkRepository, IMapper mapper) : IRequestHandler<CreateLinkRequest, Response<CreateLinkResponse>>
	{
		private readonly IUnitOfWork _unitOfWork = unitOfWork;
		private readonly ILinkRepository _linkRepository = linkRepository;
		private readonly IMapper _mapper = mapper;

		public async Task<Response<CreateLinkResponse>> Handle(CreateLinkRequest request, CancellationToken cancellationToken)
		{
			var link = _mapper.Map<Link>(request);

			if (await _linkRepository
				.GetByTitleAndFolderId(link.Title, link.FolderId, cancellationToken) == null)
				throw new ApiException("Link already exits");

			_linkRepository.Create(link);

			await _unitOfWork.Commit(cancellationToken);

			var response = _mapper.Map<CreateLinkResponse>(link);

			return new Response<CreateLinkResponse>(response);
		}
	}
}
