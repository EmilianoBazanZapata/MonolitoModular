using MediatR;
using Modules.WorkManagement.Core.DTOs.Project;

namespace Modules.WorkManagement.Application.Features.Projects.Queries.GetProjectById;

public class GetProjectByIdQuery(int id) : IRequest<GetProjectDto>
{
    public int Id { get; set; } = id;
}