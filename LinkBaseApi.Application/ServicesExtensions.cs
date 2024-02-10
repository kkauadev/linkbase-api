using FluentValidation;
using LinkBaseApi.Application.Services;
using LinkBaseApi.Application.Shared.Behavior;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Infrastructure.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LinkBaseApi.Application
{
    public static class ServicesExtensions
    {
        public static void ConfigureApplicationApp(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddScoped<IAuthenticationService, AuthenticationService>();
			services.AddScoped<IPasswordHashService, PasswordHashService>();
		}
	}
}
