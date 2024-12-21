using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.Shared.Exceptions;
using Modules.WorkManagement.Core.DTOs.Project;
using Modules.WorkManagement.Infrastructure.Persistence;

namespace Modules.WorkManagement.Application.Features.Projects.Commands.UpdateProject;

public class UpdateProjectCommandHandler(WorkManagementDbContext context) : IRequestHandler<UpdateProjectCommand, GetProjectDto>
{
    public async Task<GetProjectDto> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await context.Projects.FirstOrDefaultAsync(p =>p.Id == request.Id, cancellationToken: cancellationToken);

        if (project == null)
            throw new NotFoundException($"Project with ID {request.Id} not found.");
        
        project.Name = request.Name;
        project.UpdatedAt = DateTime.UtcNow;
        project.Description = request.Description;

        context.Projects.Update(project);
        await context.SaveChangesAsync(cancellationToken);
        
        return new GetProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            CreatedAt = project.CreatedAt,
            UpdatedAt = project.UpdatedAt
        };
    }
}