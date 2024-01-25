using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Infrastructure.Context;

namespace LinkBaseApi.Infrastructure.Repositories
{
	public class UnitOfWork(DataContext dataContext) : IUnitOfWork
	{
		readonly DataContext _context = dataContext;

		public async Task Commit(CancellationToken cancellationToken)
		{
			await _context.SaveChangesAsync(cancellationToken);
		}
	}
}
