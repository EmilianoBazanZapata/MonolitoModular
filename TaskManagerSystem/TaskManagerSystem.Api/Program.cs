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

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

var app = builder.Build();

// Middleware de manejo de errores
app.UseMiddleware<ErrorHandlingMiddleware>();

// Configuraci�n del pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Aseg�rate de que estos middlewares est�n configurados correctamente
app.UseAuthentication(); // Middleware de autenticaci�n
app.UseAuthorization();  // Middleware de autorizaci�n

app.UseRouting();

// Mapear controladores
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
