using LinkBaseApi.Application.Exceptions;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Domain.Interfaces.Model;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Links.DeleteLink;
public class DeleteLinkHandler(IUnitOfWork unitOfWork, ILinkRepository linkRepository) : IRequestHandler<DeleteLinkRequest, Response<DeleteLinkResponse>>
{
	private readonly IUnitOfWork _unitOfWork = unitOfWork;
	private readonly ILinkRepository _linkRepository = linkRepository;

	public async Task<Response<DeleteLinkResponse>> Handle(DeleteLinkRequest request, CancellationToken cancellationToken)
	{
		var linkExists = await _linkRepository.Get(request.Id, cancellationToken) ?? throw new ApiException("Link dont exists.");

		_linkRepository.Delete(linkExists);

		await _unitOfWork.Commit(cancellationToken);

		return new Response<DeleteLinkResponse>(new DeleteLinkResponse() { Id = request.Id });
	}
}