using LinkBaseApi;
using LinkBaseApi.Application.Services;
using LinkBaseApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistenceApp(builder.Configuration);
builder.Services.ConfigureApplicationApp();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<ExceptionHandler>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

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