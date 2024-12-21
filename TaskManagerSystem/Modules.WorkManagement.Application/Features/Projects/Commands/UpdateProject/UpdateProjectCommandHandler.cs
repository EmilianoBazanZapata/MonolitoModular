using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.WorkManagement.Core.DTOs.Project;
using Modules.WorkManagement.Infrastructure.Persistence;
using TaskManager.Shared.Core.Exceptions;

namespace Modules.WorkManagement.Application.Features.Projects.Commands.UpdateProject;

public class UpdateProjectCommandHandler(WorkManagementDbContext _context)
    : IRequestHandler<UpdateProjectCommand, GetProjectDto>
{
    public async Task<GetProjectDto> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var projectExisting = await _context.Projects.AnyAsync(p  => request.Name.Equals(p.Name) && 
                                                                            p.Id != request.Id, cancellationToken);
        
        if (projectExisting)
            throw new ConflictException($"The project {request.Name} already registered.");
        
        var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);

        if (project == null)
            throw new NotFoundException($"Project with ID {request.Id} not found.");

        project.Name = request.Name;
        project.UpdatedAt = DateTime.UtcNow;
        project.Description = request.Description;

        _context.Projects.Update(project);
        await _context.SaveChangesAsync(cancellationToken);

        return new GetProjectDto(project.Id,project.Name,project.Description,project.CreatedAt,project.UpdatedAt);
    }
}