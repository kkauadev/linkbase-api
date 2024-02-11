using LinkBaseApi.Domain.Interfaces.Model;
using LinkBaseApi.Domain.Models;
using LinkBaseApi.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LinkBaseApi.Infrastructure.Persistence.Repositories
{
    public class UserRepository(DataContext dataContext) : BaseRepository<User>(dataContext), IUserRepository
    {
        public async Task<User?> GetByUsername(string username, CancellationToken cancellationToken)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(x => x.Username == username, cancellationToken);
        }

        public async Task<User?> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await _dataContext.Users
                .FirstOrDefaultAsync(u => u.Id.Equals(id), cancellationToken);
        }

        public async Task<List<User>> GetAllWithFolders(CancellationToken cancellationToken)
        {
            return await _dataContext.Users
                .Include(u => u.Folders)
                .ToListAsync(cancellationToken);
        }

        public async Task<User?> GetByEmailOrUsername(string email, string username, CancellationToken cancellationToken)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(x => x.Username == username || x.Email == email, cancellationToken);
        }
    }
}
