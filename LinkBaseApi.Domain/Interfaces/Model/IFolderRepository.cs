using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Domain.Interfaces.Model
{
    public interface IFolderRepository : IBaseRepository<Folder>
    {
        Task<Folder?> GetWithLinks(Guid id, CancellationToken cancellationToken);
        Task<ICollection<Folder>> GetByAuthor(Guid authorId, CancellationToken cancellationToken);
    }
}
