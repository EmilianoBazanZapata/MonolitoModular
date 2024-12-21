using Modules.WorkManagement.Application.Features.Common;

namespace Modules.WorkManagement.Application.Features.Tasks.Commands.CreateTask;


public record CreateTaskCommand(int ProjectId, DateTime DueDate) : BaseCommand<int>;
