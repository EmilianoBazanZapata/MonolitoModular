using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.WorkManagement.Core.DTOs.Project;
using Modules.WorkManagement.Infrastructure.Persistence;

namespace Modules.WorkManagement.Application.Features.Projects.Queries.GetAllProjects;

public class GetAllProjectsQueryHandler(WorkManagementDbContext context) : IRequestHandler<GetAllProjectsQuery, IEnumerable<GetProjectDto>>
{
    public async Task<IEnumerable<GetProjectDto>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = await context.Projects.ToListAsync(cancellationToken: cancellationToken);
        
        return projects.Select(project => new GetProjectDto(project.Id,project.Name,project.Description,project.CreatedAt,project.UpdatedAt));
    }
}