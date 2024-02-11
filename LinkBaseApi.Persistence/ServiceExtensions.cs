using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Infrastructure.Persistence.Repositories;
using LinkBaseApi.Infrastructure.Persistence.Context;
using LinkBaseApi.Domain.Interfaces.Model;

namespace LinkBaseApi.Infrastructure
{
    public static class ServiceExtensions
	{
		public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration)
		{
			//var connectionString = configuration.GetConnectionString("");
			var connectionString = "Host=localhost;Database=linkbase;Username=admin;Password=admin";

			services.AddDbContext<DataContext>(opt => opt.UseNpgsql(connectionString));

			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IFolderRepository, FolderRepository>();
			services.AddScoped<ILinkRepository, LinkRepository>();

			AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", false);
		}
	}
}
