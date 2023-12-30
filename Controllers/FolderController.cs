using AutoMapper;
using LinkBaseApi.Context;
using LinkBaseApi.DTOs;
using LinkBaseApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinkBaseApi.Controllers
{
  public class FolderController : ControllerBase
  {
    public readonly ILogger<FolderController> _logger;
    public readonly DataContext _dataContext;
    public readonly IMapper _mapper;

    public FolderController(ILogger<FolderController> logger, DataContext dataContext, IMapper mapper)
    {
      _logger = logger;
      _dataContext = dataContext;
      _mapper = mapper;
    }

    [HttpGet("/folders/{id}")]
    public async Task<ActionResult<List<Folder>>> GetFoldersByUser(string id)
    {
      if (!Guid.TryParse(id, out Guid userId))
      {
        return BadRequest("Insira um ID válido");
      }

      return await _dataContext.Folders.Where(p => p.UserId == userId).ToListAsync();
    }

    [HttpPost("/folder/{authorId}")]
    public async Task<ActionResult<Folder>> CreateFolder(string authorId, [FromBody] FolderDTO folderDTO)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest();
      }
      if (!Guid.TryParse(authorId, out Guid userId))
      {
        return BadRequest("Insira um ID válido");
      }

      User? user = await _dataContext.Users.FindAsync(userId);

      if (user == null)
      {
        return BadRequest();
      }

      Folder folder = new()
      {
        UserId = userId,
        Name = folderDTO.Name,
      };

      _dataContext.Folders.Add(folder);
      await _dataContext.SaveChangesAsync();

      return CreatedAtAction(nameof(CreateFolder), new { id = folder.Id }, folder);
    }

    [HttpDelete("/folder/{authorId}/{id}")]
    public async Task<ActionResult<Folder>> DeleteFolder(string authorId, string id)
    {
      if (!Guid.TryParse(authorId, out Guid userId))
      {
        return BadRequest("Insira um ID de usuário válido");
      }

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

    [HttpPut("/folder/{authorId}/{id}")]
    public async Task<ActionResult<Folder>> UpdateFolderById(string authorId, string id,[FromBody] FolderDTO folderDTO)
    {
      if (!Guid.TryParse(authorId, out Guid userId))
      {
        return BadRequest("Insira um ID de usuário válido");
      }

      if (!Guid.TryParse(id, out Guid folderId))
      {
        return BadRequest("Insira um ID de pasta válido");
      }

      Folder? folder = _dataContext.Folders.Find(folderId);
      if (folder == null)
      {
        return BadRequest();
      }

      if (!string.IsNullOrEmpty(folderDTO.Name))
      {
        folder.Name = folderDTO.Name;
      }
      if (!string.IsNullOrEmpty(folderDTO.Description))
      {
        folder.Description = folderDTO.Description;
      }

      _dataContext.Update(folder);
      await _dataContext.SaveChangesAsync();

      return Ok();
    }
  }
}
