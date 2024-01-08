using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Domain.Interfaces
{
  public interface IFolderRepository : IBaseRepository<Folder>
  {
    Task<Folder?> GetByAuthor(Guid authorId, CancellationToken cancellationToken);
  }
}
