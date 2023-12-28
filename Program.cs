using linkbase_api.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<DataContext>(options =>
{
  //var connectionString = Environment.GetEnvironmentVariable("DEFAULT_CONNECTION");
  var connectionString = "Host=localhost;Database=linkbase;Username=admin;Password=admin";
  options.UseNpgsql(connectionString);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
}

app.MapControllers();

app.Run();