using LinkBaseApi.Domain.Models;

namespace LinkBaseApi.Domain.Interfaces
{
  public interface IUserRepository : IBaseRepository<User>
  {
    Task<User?> GetByUsername(string username, CancellationToken cancellationToken);
		Task<User?> GetWithFolders(Guid id, CancellationToken cancellationToken);
  }
}
