using LinkBaseApi.Context;
using LinkBaseApi.DTOs;
using LinkBaseApi.Models;
using LinkBaseApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkBaseApi.Controllers
{
  public class LinkController (ILogger<LinkController> logger, DataContext dataContext, ValidationService validationService) : ControllerBase
  {
    public readonly ILogger _logger = logger;
    public readonly DataContext _dataContext = dataContext;
    public readonly ValidationService _validationService = validationService;

    [HttpPost("/link/{id}")]
    public async Task<ActionResult<LinkDTOView>> CreateLink(string id, [FromBody] LinkDTO linkDTO)
    {
      if (!Guid.TryParse(id, out Guid folderId))
      {
        return BadRequest("Insira um ID válido");
      }

      if (_dataContext.Links.Any(l => l.Title == linkDTO.Title)) { }

      Link link = new()
      {
        FolderId = folderId,
        Description = linkDTO.Description,
        Title = linkDTO.Title,
        Url = linkDTO.Url
      };

      _dataContext.Add(link);
      await _dataContext.SaveChangesAsync();

      return Ok(link);
    }
  }

}
