using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Domain.Interfaces.Model
{
    public interface ILinkRepository : IBaseRepository<Link>
    {
        Task<List<Link>> GetByFolderId(Guid folderId, CancellationToken cancellationToken);
        Task<Link?> GetByTitleAndId(string title, Guid folderId, CancellationToken cancellationToken);
    }
}
