using LinkBaseApi.Application.UseCases.Folders.CreateFolder;
using LinkBaseApi.Application.UseCases.Folders.DeleteFolder;
using LinkBaseApi.Application.UseCases.Folders.GetAllFolders;
using LinkBaseApi.Application.UseCases.Folders.GetFolder;
using LinkBaseApi.Application.UseCases.Folders.GetFoldersFromUser;
using LinkBaseApi.Application.UseCases.Folders.UpdateFolder;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LinkBaseApi.Controllers
{
	public class FolderController
    (ILogger<FolderController> logger, IMediator mediator) : ControllerBase
    {
        private readonly ILogger<FolderController> _logger = logger;
        private readonly IMediator _mediator = mediator;

        [HttpGet("/folders")]
        public async Task<ActionResult<Response<List<GetAllFoldersResponse>>>> GetAllFolders
            (CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllFoldersRequest(), cancellationToken);

            return Ok(response);
        }

        [HttpGet("/folders/{id}")]
        public async Task<ActionResult<GetFolderResponse>> GetFolders(Guid id)
        {
            var response = await _mediator.Send(new GetFolderRequest() { Id = id });

            return Ok(response);
        }

        [HttpGet("/user/folders/{userId}")]
        public async Task<ActionResult<List<GetFoldersFromUserResponse>>> GetUserFolders
            (Guid userId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetFolderFromUserRequest() { UserId = userId }, cancellationToken);

            return Ok(response);
        }

        [HttpPost("/folder")]
        public async Task<ActionResult<Response<CreateFolderResponse>>> CreateFolder
            ([FromBody] CreateFolderRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        [HttpDelete("/folder/{id}")]
        public async Task<ActionResult<Response<DeleteFolderResponse>>> DeleteFolder
            (Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteFolderRequest() { Id = id }, cancellationToken);

            return Ok(response);
        }

        [HttpPut("/folder/{id}")]
        public async Task<ActionResult<Response<UpdateFolderResponse>>> UpdateFolderByI
            (Guid id, [FromBody] UpdateFolderDTO folderDTO, CancellationToken cancellationToken)
        {
            var request = new UpdateFolderRequest() { Id = id, Name = folderDTO.Name, Description = folderDTO.Description };

            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }
    }
}
