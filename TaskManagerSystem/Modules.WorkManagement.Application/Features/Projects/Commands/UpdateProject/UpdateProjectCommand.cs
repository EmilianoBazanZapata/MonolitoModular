using Modules.WorkManagement.Application.Features.Common;
using Modules.WorkManagement.Core.DTOs.Project;

namespace Modules.WorkManagement.Application.Features.Projects.Commands.UpdateProject;

public record UpdateProjectCommand(int Id, DateTime StartDate, DateTime EndDate, DateTime? UpdatedAt) : BaseCommand<GetProjectDto> { }