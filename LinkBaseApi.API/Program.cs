using LinkBaseApi;
using LinkBaseApi.Application;
using LinkBaseApi.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		var config = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
			.AddEnvironmentVariables()	
			.Build();

		builder.Services.ConfigurePersistenceApp(builder.Configuration);
		builder.Services.ConfigureApplicationApp();

		builder.Services.AddAuthentication(x =>
		{
			x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
		}).AddJwtBearer(x =>
		{
			x.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = false,
				ValidateAudience = false,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
			};
		});

		builder.Services.AddAuthorization();

		builder.Services.AddControllers();

		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen(config =>
		{
			config.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });

			config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
			{
				Description = "JWT Token",
				Type = SecuritySchemeType.Http,
				Scheme = "bearer"
			});

			config.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer" 
						}
					},
					Array.Empty<string>()
				}
			});
		});
		builder.Services.AddExceptionHandler<ExceptionHandler>();

		builder.Services.AddRouting(options => options.LowercaseUrls = true);

		var app = builder.Build();

		app.UseAuthentication();
		app.UseAuthorization();

		app.UseSwagger();
		app.UseSwaggerUI();
		app.UseExceptionHandler(builder =>
		{
		});

		//if (app.Environment.IsDevelopment())
		//{ 
		//app.UseDeveloperExceptionPage();
		//}

		app.UseCors("AllowAllOrigins");
		app.MapControllers();

		app.Run();
	}
}