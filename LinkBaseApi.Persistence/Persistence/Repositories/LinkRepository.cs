using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Domain.Models;
using LinkBaseApi.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LinkBaseApi.Infrastructure.Persistence.Repositories
{
    public class LinkRepository(DataContext dataContext) : BaseRepository<Link>(dataContext), ILinkRepository
    {
        public async Task<List<Link>> GetByFolderId(Guid folderId, CancellationToken cancellationToken)
        {
            return await _dataContext.Links.Where(l => l.FolderId == folderId).ToListAsync(cancellationToken);
        }
    }
}
