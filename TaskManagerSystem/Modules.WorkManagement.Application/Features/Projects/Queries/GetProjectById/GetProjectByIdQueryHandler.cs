using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.WorkManagement.Core.DTOs.Project;
using Modules.WorkManagement.Infrastructure.Persistence;
using TaskManager.Shared.Core.Exceptions;

namespace Modules.WorkManagement.Application.Features.Projects.Queries.GetProjectById;

public class GetProjectByIdQueryHandler(WorkManagementDbContext context) : IRequestHandler<GetProjectByIdQuery, GetProjectDto>
{

    public async Task<GetProjectDto> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await context.Projects.FirstOrDefaultAsync(p =>p.Id == request.Id, cancellationToken: cancellationToken);

        if (project == null)
            throw new NotFoundException($"Project with ID {request.Id} not found.");

        return new GetProjectDto(project.Id, project.Name, project.Description, project.CreatedAt, project.UpdatedAt);
    }
}