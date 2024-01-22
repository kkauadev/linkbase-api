using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Domain.Models;
using LinkBaseApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LinkBaseApi.Persistence.Repositories
{
  public class FolderRepository(DataContext dataContext) : BaseRepository<Folder>(dataContext), IFolderRepository
  {
    public async Task<Folder?> GetByAuthor(Guid authorId, CancellationToken cancellationToken)
    {
      return await _dataContext.Folders
        .FirstOrDefaultAsync(f => f.UserId == authorId, cancellationToken);
    }
  }
}
