using AutoMapper;
using LinkBaseApi.Application.Exceptions;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Links.UpdateLink
{
	public class UpdateLinkHandler(IUnitOfWork unitOfWork, ILinkRepository linkRepository, IMapper mapper) : IRequestHandler<UpdateLinkRequest, Response<UpdateLinkResponse>>
	{
		private readonly IUnitOfWork _unitOfWork = unitOfWork;
		private readonly ILinkRepository _linkRepository = linkRepository;
		private readonly IMapper _mapper = mapper;
		public async Task<Response<UpdateLinkResponse>> Handle(UpdateLinkRequest request, CancellationToken cancellationToken)
		{
			var existingLink = await _linkRepository.Get(request.Id, cancellationToken) ?? throw new ApiException("Link Not Found.");

			_mapper.Map(request, existingLink);

			_linkRepository.Update(existingLink);

			await _unitOfWork.Commit(cancellationToken);

			var response = _mapper.Map<UpdateLinkResponse>(existingLink);

			return new Response<UpdateLinkResponse>(response);
		}
	}
}
