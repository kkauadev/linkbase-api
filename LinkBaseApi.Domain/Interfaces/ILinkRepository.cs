using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Domain.Interfaces
{
  public interface ILinkRepository : IBaseRepository<Link>
  {
    Task<List<Link>> GetByFolderId(Guid folderId, CancellationToken cancellationToken);
  }
}
