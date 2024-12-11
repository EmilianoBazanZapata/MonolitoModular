using TaskManagerSystem.Application;
using TaskManagerSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration.GetConnectionString("DefaultConnection"), 
    builder.Configuration.GetConnectionString("IdentityConnection"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar middlewares
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
