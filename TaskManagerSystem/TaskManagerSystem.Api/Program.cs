using TaskManagerSystem.Api;
using TaskManagerSystem.Api.Mappings;
using TaskManagerSystem.Application;
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

var app = builder.Build();

// Middleware de captura de errores
app.UseMiddleware<TaskManagerSystem.Api.Middlewares.ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();