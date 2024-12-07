using TaskManagerSystem.Api;
using TaskManagerSystem.Api.Filters;
using TaskManagerSystem.Application;
using TaskManagerSystem.Application.Mappings;
using TaskManagerSystem.Core;
using TaskManagerSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Registrar configuraciones de Mapster
MapsterConfig.RegisterMappings();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCoreServices();
builder.Services.AddInfrastructureServices(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddApplicationServices();
builder.Services.AddApiServices();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidateModelAttribute>();
});

var app = builder.Build();

// Middleware de captura de errores
app.UseMiddleware<TaskManagerSystem.Api.Middlewares.ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHttpsRedirection();

app.Run();