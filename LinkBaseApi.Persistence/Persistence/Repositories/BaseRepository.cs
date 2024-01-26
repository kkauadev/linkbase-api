using LinkBaseApi.Domain.Common;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LinkBaseApi.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<T>(DataContext dataContext) : IBaseRepository<T> where T : BaseEntity
    {
        public readonly DataContext _dataContext = dataContext;

        public void Create(T entity)
        {
            _dataContext.Add(entity);
        }

        public void Delete(T entity)
        {
            _dataContext.Remove(entity);
        }

        public void Update(T entity)
        {
            entity.LastUpdated = DateTimeOffset.UtcNow;
            _dataContext.Update(entity);
        }

        public async Task<T?> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _dataContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return await _dataContext.Set<T>().ToListAsync(cancellationToken);
        }
    }
}
