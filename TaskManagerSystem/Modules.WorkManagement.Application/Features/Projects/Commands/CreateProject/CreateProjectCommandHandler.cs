using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.WorkManagement.Core.Entities;
using Modules.WorkManagement.Infrastructure.Persistence;
using TaskManager.Shared.Core.Exceptions;

namespace Modules.WorkManagement.Application.Features.Projects.Commands.CreateProject;

public class CreateProjectCommandHandler(WorkManagementDbContext _context) : IRequestHandler<CreateProjectCommand, int>
{
    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var projectExisting = await _context.Projects.AnyAsync(p => p.Name == request.Name, cancellationToken);

        if (projectExisting)
            throw new ConflictException($"The project {request.Name} already registered.");
        
        var project = new Project
        {
            Name = request.Name,
            Description = request.Description,
            CreatedAt = DateTime.UtcNow
        };

        _context.Projects.Add(project);

        await _context.SaveChangesAsync(cancellationToken);

        return project.Id;
    }
}