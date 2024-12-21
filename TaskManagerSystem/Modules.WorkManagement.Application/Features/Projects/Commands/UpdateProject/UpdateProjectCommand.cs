using MediatR;
using Modules.WorkManagement.Core.DTOs.Project;

namespace Modules.WorkManagement.Application.Features.Projects.Commands.UpdateProject;

public class UpdateProjectCommand : IRequest<GetProjectDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
}