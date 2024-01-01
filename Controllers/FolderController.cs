using LinkBaseApi.Services;
using LinkBaseApi.Context;
using LinkBaseApi.DTOs;
using LinkBaseApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinkBaseApi.Controllers
{
  public class FolderController
      (ILogger<FolderController> logger, DataContext dataContext, ValidationService validationService) : ControllerBase
  {
    public readonly ILogger<FolderController> _logger = logger;
    public readonly DataContext _dataContext = dataContext;
    public readonly ValidationService _validationService = validationService;

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

    [HttpPost("/folder/{authorId}")]
    public async Task<ActionResult<FolderViewDTO>> CreateFolder(string authorId, [FromBody] FolderDTO folderDTO)
    {
      var (isValid, errorMessage) = _validationService.ValidateFolderCreation(folderDTO);

      if (!isValid)
      {
        return BadRequest(errorMessage);
      }

      if (!Guid.TryParse(authorId, out Guid userId))
      {
        return BadRequest("Insira um ID válido");
      }

      User? user = await _dataContext.Users.FindAsync(userId);

      if (user == null)
      {
        return BadRequest("Usuário não encontrado");
      }

      Folder folder = new()
      {
        UserId = userId,
        Name = folderDTO.Name,
        Description = folderDTO.Description ?? null,
        Links = new List<Link>()
      };

      _dataContext.Folders.Add(folder);
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

      return CreatedAtAction(
        nameof(CreateFolder),
        new { id = folder.Id },
        folderView
      );
    }

    [HttpDelete("/folder/{id}")]
    public async Task<ActionResult<Folder>> DeleteFolder(string id)
    {
      if (!Guid.TryParse(id, out Guid folderId))
      {
        return BadRequest("Insira um ID de pasta válido");
      }

      Folder? folder = await _dataContext.Folders.FindAsync(folderId);

      if (folder == null)
      {
        return BadRequest("Essa pasta não existe");
      }

      _dataContext.Folders.Remove(folder);
      await _dataContext.SaveChangesAsync();

      return Ok($"Pasta ({folder.Name} - {folder.Id}) removida com sucesso");
    }

    [HttpPut("/folder/{id}")]
    public async Task<ActionResult<FolderViewDTO>> UpdateFolderById(string id,[FromBody] FolderDTOUpdate folderDTOUpdate)
    {
      var (isValid, errorMessage) = _validationService.ValidateFolderUpdate(folderDTOUpdate);

      if (!isValid) return BadRequest(errorMessage); 

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
