using Modules.WorkManagement.Core.Extensions;
using Modules.WorkManagement.Infrastructure.Extensions;
using Modules.WorkManagement.Controllers.Extensions;
using TaskManager.Shared.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSharedInfrastructure(builder.Configuration);
builder.Services.AddWorkManagementInfrastructure(builder.Configuration);
builder.Services.AddWorkManagementCore();
builder.Services.AddWorkManagementControllers(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();