using Modules.WorkManagement.Application.Features.Common;

namespace Modules.WorkManagement.Application.Features.Projects.Commands.CreateProject;

public record CreateProjectCommand(DateTime StartDate, DateTime EndDate) : BaseCommand<int>;