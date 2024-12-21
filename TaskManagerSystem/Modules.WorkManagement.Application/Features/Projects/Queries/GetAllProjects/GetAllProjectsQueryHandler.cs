using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.WorkManagement.Core.DTOs.Project;
using Modules.WorkManagement.Core.Entities;
using Modules.WorkManagement.Infrastructure.Persistence;

namespace Modules.WorkManagement.Application.Features.Projects.Queries.GetAllProjects;

public class GetAllProjectsQueryHandler(WorkManagementDbContext context) : IRequestHandler<GetAllProjectsQuery, IEnumerable<GetProjectDto>>
{
    public async Task<IEnumerable<GetProjectDto>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        // Obtener todos los proyectos
        var projects = await context.Projects.ToListAsync(cancellationToken: cancellationToken);

        // Mapear a DTO
        return projects.Select(project => new GetProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            CreatedAt = project.CreatedAt,
            UpdatedAt = project.UpdatedAt
        }).ToList();
    }
}