using LinkBaseApi.Application.UseCases.Links.CreateLink;
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

        [HttpPost("folder/link/{folderId}")]
        public async Task<ActionResult<Response<CreateLinkResponse>>> CreateLink(Guid folderId, [FromBody] CreateLinkDTO linkDTO, CancellationToken cancellationToken)
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
    }
}