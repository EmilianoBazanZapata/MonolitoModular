using MediatR;
using Modules.WorkManagement.Core.Entities;
using Modules.WorkManagement.Infrastructure.Persistence;

namespace Modules.WorkManagement.Application.Features.Projects.Commands.CreateProject;

public class CreateProjectCommandHandler(WorkManagementDbContext context) : IRequestHandler<CreateProjectCommand, int>
{
    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project
        {
            Name = request.Name,
            Description = request.Description,
            CreatedAt = DateTime.UtcNow
        };

        context.Projects.Add(project);
        
        await context.SaveChangesAsync(cancellationToken);

        return project.Id;
    }
}