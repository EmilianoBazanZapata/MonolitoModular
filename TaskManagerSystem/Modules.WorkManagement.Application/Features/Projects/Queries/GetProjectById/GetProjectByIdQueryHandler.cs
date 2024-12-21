using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.Shared.Exceptions;
using Modules.WorkManagement.Core.DTOs.Project;
using Modules.WorkManagement.Infrastructure.Persistence;

namespace Modules.WorkManagement.Application.Features.Projects.Queries.GetProjectById;

public class GetProjectByIdQueryHandler(WorkManagementDbContext context) : IRequestHandler<GetProjectByIdQuery, GetProjectDto>
{

    public async Task<GetProjectDto> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await context.Projects.FirstOrDefaultAsync(p =>p.Id == request.Id, cancellationToken: cancellationToken);

        if (project == null)
            throw new NotFoundException($"Project with ID {request.Id} not found.");

        return new GetProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            CreatedAt = project.CreatedAt,
            UpdatedAt = project.UpdatedAt
        };
    }
}