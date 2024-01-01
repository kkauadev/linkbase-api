using LinkBaseApi.Services;
using LinkBaseApi.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
  var connectionString = Environment.GetEnvironmentVariable("DEFAULT_CONNECTION");
  options.UseNpgsql(connectionString);
});

builder.Services.AddScoped<ValidationService>();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
}

app.UseCors("AllowAllOrigins");
app.MapControllers();

app.Run();