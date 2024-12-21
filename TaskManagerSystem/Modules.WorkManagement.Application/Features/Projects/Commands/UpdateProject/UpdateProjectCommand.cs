using Modules.WorkManagement.Application.Features.Common;
using Modules.WorkManagement.Core.DTOs.Project;

namespace Modules.WorkManagement.Application.Features.Projects.Commands.UpdateProject;

public class UpdateProjectCommand : BaseCommand<GetProjectDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime? UpdatedAt { get; set; } 
}