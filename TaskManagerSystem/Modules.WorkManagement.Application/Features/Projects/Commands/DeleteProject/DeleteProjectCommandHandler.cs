using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.WorkManagement.Infrastructure.Persistence;
using TaskManager.Shared.Core.Exceptions;

namespace Modules.WorkManagement.Application.Features.Projects.Commands.DeleteProject;

public class DeleteProjectCommandHandler(WorkManagementDbContext context) : IRequestHandler<DeleteProjectCommand, Unit>
{

    public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await context.Projects.FirstOrDefaultAsync(p =>p.Id == request.Id, cancellationToken: cancellationToken);
        
        if (project == null)
            throw new NotFoundException($"Project with Id: {request.Id} was not found.");
        
        context.Projects.Remove(project);
        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}