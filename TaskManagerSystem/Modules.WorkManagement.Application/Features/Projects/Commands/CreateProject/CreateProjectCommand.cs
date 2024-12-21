using Modules.WorkManagement.Application.Features.Common;

namespace Modules.WorkManagement.Application.Features.Projects.Commands.CreateProject;

public class CreateProjectCommand : BaseCommand<int>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}