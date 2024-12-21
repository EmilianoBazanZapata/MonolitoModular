using Modules.WorkManagement.Application.Features.Common;

namespace Modules.WorkManagement.Application.Features.Tasks.Commands.UpdateTask;

public record UpdateTaskCommand(int Id, int ProjectId, DateTime DueDate) : BaseCommand<int>;