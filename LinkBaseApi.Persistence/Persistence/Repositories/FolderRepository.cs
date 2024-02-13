using LinkBaseApi.Domain.Interfaces.Model;
using LinkBaseApi.Domain.Models;
using LinkBaseApi.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LinkBaseApi.Infrastructure.Persistence.Repositories
{
    public class FolderRepository(DataContext dataContext) : BaseRepository<Folder>(dataContext), IFolderRepository
    {
        public async Task<ICollection<Folder>> GetByAuthor(Guid authorId, CancellationToken cancellationToken)
        {
            return await _dataContext.Folders
              .Where(f => f.UserId == authorId)
              .ToListAsync(cancellationToken: cancellationToken);
        }

		public async Task<Folder?> GetWithLinks(Guid id, CancellationToken cancellationToken)
		{
            return await _dataContext.Folders
                .Include(f => f.Links)
                .FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
                
		}
	}
}
