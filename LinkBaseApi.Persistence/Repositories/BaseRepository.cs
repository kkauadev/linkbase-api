﻿using LinkBaseApi.Domain.Common;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LinkBaseApi.Persistence.Repositories
{
    public class BaseRepository<T>(DataContext dataContext) : IBaseRepository<T> where T : BaseEntity
    {
        public readonly DataContext _dataContext = dataContext;

        public void Create(T entity)
        {
            entity.Id = Guid.NewGuid();
            entity.Created = DateTime.Now;
            _dataContext.Add(entity);
        }

        public void Delete(Guid id, CancellationToken cancellationToken)
        {
            var entity = Get(id, cancellationToken);
            _dataContext.Remove(entity);
        }

		public void Update(T entity)
		{
			entity.LastUpdated = DateTime.Now;
			_dataContext.Update(entity);
		}

		public async Task<T?> Get(Guid id, CancellationToken cancellationToken)
        {
			return await _dataContext.Set<T>().FindAsync([id, cancellationToken], cancellationToken: cancellationToken);
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return await _dataContext.Set<T>().ToListAsync(cancellationToken);
        }
    }
}
