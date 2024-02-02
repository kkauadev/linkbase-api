using LinkBaseApi.Application.UseCases.Links.CreateLink;
using LinkBaseApi.Application.UseCases.Links.DeleteLink;
using LinkBaseApi.Application.UseCases.Links.GetAllLinks;
using LinkBaseApi.Application.UseCases.Links.GetLinkByFolder;
using LinkBaseApi.Application.UseCases.Links.GetLinks;
using LinkBaseApi.Application.UseCases.Links.UpdateLink;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LinkBaseApi.Controllers
{
	public class LinkController(ILogger<LinkController> logger, IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger _logger = logger;

        [HttpGet("links")]
        public async Task<ActionResult<Response<GetLinksResponse>>> GetAllLinks(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetLinksRequest(), cancellationToken);

            return Ok(response);
        }

        [HttpGet("links/{folderId}")]
        public async Task<ActionResult<Response<List<GetLinkByFolderResponse>>>> GetLinksByFolder
            (Guid folderId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetLinkByFolderRequest { FolderId = folderId }, cancellationToken);

            return Ok(response);
        }

        [HttpPost("folder/link/{folderId}")]
        public async Task<ActionResult<Response<CreateLinkResponse>>> CreateLink
            (Guid folderId, [FromBody] CreateLinkDTO linkDTO, CancellationToken cancellationToken)
        {
            var linkRequest = new CreateLinkRequest()
            {
                FolderId = folderId,
                Title = linkDTO.Title,
                Url = linkDTO.Url,
                Description = linkDTO.Description,
            };

            var response = await _mediator.Send(linkRequest, cancellationToken);

            return Ok(response);
        }

        [HttpDelete("link/{id}")]
        public async Task<ActionResult<Response<DeleteLinkResponse>>> DeleteLink(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteLinkRequest { Id = id }, cancellationToken);

            return Ok(response);
        }

        [HttpPut("link/{id}")]
        public async Task<ActionResult<Response<UpdateLinkResponse>>> UpdateLink
            (Guid id, [FromBody] UpdateLinkDTO linkDTO, CancellationToken cancellationToken)
        {
            var request = new UpdateLinkRequest() { Id = id, Title = linkDTO.Title, Url = linkDTO.Url, Description = linkDTO.Description };

            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }
    }
}