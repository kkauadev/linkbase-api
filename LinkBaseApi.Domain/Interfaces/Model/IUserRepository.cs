using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Domain.Interfaces.Model
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByUsername(string username, CancellationToken cancellationToken);
        Task<User?> GetById(Guid id, CancellationToken cancellationToken);
        Task<List<User>> GetAllWithFolders(CancellationToken cancellationToken);
        Task<User?> GetByEmailOrUsername(string email, string username, CancellationToken cancellationToken);
    }
}
