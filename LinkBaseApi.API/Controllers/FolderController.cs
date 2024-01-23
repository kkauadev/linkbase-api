using LinkBaseApi.Application.DTOs;
using LinkBaseApi.Application.UseCases.Folders.CreateFolder;
using LinkBaseApi.Application.UseCases.Folders.DeleteFolder;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.DTOs;
using LinkBaseApi.Domain.Models;
using LinkBaseApi.Persistence.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinkBaseApi.Controllers
{
    public class FolderController
    (ILogger<FolderController> logger, DataContext dataContext, IMediator mediator) : ControllerBase
    {
        private readonly ILogger<FolderController> _logger = logger;
        private readonly DataContext _dataContext = dataContext;
        private readonly IMediator _mediator = mediator;

        [HttpGet("/folders/{authorId}")]
        public async Task<ActionResult<List<FolderViewDTO>>> GetFoldersByUser(string authorId)
        {
            if (!Guid.TryParse(authorId, out Guid userId))
            {
                return BadRequest("Insira um ID válido");
            }

            List<FolderViewDTO> folders = await _dataContext.Folders
               .Include(f => f.Links)
               .Where(f => f.UserId == userId)
               .Select(f => new FolderViewDTO()
               {
                   Id = f.Id,
                   Name = f.Name,
                   Description = f.Description,
                   Links = (f.Links.Count == 0) ? null : f.Links.Select(l => new LinkDTOView()
                   {
                       Id = l.Id,
                       Description = l.Description,
                       Title = l.Title,
                       Url = l.Url,
                   }).ToList()
               })
               .ToListAsync();

            return Ok(folders);
        }

        [HttpPost("/folder")]
        public async Task<ActionResult<Response<CreateFolderResponse>>> CreateFolder
            ([FromBody] CreateFolderRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        [HttpDelete("/folder/{id}")]
        public async Task<ActionResult<Folder>> DeleteFolder
            (Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteFolderRequest() { Id = id }, cancellationToken);

            return Ok(response);
        }

        [HttpPut("/folder/{id}")]
        public async Task<ActionResult<FolderViewDTO>> UpdateFolderById(string id, [FromBody] FolderDTOUpdate folderDTOUpdate)
        {
            if (!Guid.TryParse(id, out Guid folderId))
            {
                return BadRequest("Insira um ID de pasta válido");
            }

            Folder? folder = _dataContext.Folders.Find(folderId);
            if (folder == null)
            {
                return BadRequest("A pasta inserida não existe");
            }

            if (!string.IsNullOrEmpty(folderDTOUpdate.Name))
            {
                folder.Name = folderDTOUpdate.Name;
            }
            if (!string.IsNullOrEmpty(folderDTOUpdate.Description))
            {
                folder.Description = folderDTOUpdate.Description;
            }

            _dataContext.Update(folder);
            await _dataContext.SaveChangesAsync();

            FolderViewDTO folderView = new()
            {
                Id = folder.Id,
                Name = folder.Name,
                Description = folder.Description,
                Links = (folder.Links ?? new List<Link>()).Select(l => new LinkDTOView
                {
                    Id = l.Id,
                    Description = l.Description,
                    Title = l.Title,
                    Url = l.Url,
                }).ToList()
            };

            return Ok(folderView);
        }
    }
}
