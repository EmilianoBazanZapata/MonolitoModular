using Modules.User.Users.Extensions;
using Modules.Users.Application.Extensions;
using Modules.Users.Controllers.Extensions;
using Modules.WorkManagement.Application.Extensions;
using Modules.WorkManagement.Core.Extensions;
using Modules.WorkManagement.Infrastructure.Extensions;
using Modules.WorkManagement.Controllers.Extensions;
using TaskManager.Shared.Core.Middlewares;
using TaskManager.Shared.Infrastructure.Extensions;
using Modules.Users.Infrastructure.Extensions;
using TaskManager.Shared.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSharedApplication(builder.Configuration);

// Configuraci�n compartida
builder.Services.AddSharedInfrastructure(builder.Configuration);

// Configuraci�n del m�dulo de usuarios
builder.Services.AddUserApplication();
builder.Services.AddUserInfrastructure(builder.Configuration);
builder.Services.AddUserCore();
builder.Services.AddUServiceCollectionControllers(builder.Configuration);

// Configuraci�n del m�dulo de gesti�n de trabajo
builder.Services.AddWorkManagementApplication();
builder.Services.AddWorkManagementInfrastructure(builder.Configuration);
builder.Services.AddWorkManagementCore();
builder.Services.AddWorkManagementControllers(builder.Configuration);

// Registrar servicios de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Aplicar semilla de datos
await app.Services.SeedDataAsync();

// Configurar middlewares
app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
