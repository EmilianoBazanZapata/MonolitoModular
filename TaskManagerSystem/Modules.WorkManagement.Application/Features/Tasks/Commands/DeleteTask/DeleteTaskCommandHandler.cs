using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.WorkManagement.Core.Abstractions;
using TaskManager.Shared.Core.Exceptions;

namespace Modules.WorkManagement.Application.Features.Tasks.Commands.DeleteTask;

public class DeleteTaskCommandHandler(IWorkManagementDbContext _context) : IRequestHandler<DeleteTaskCommand, Unit>
{
    public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _context.ToDoTasks.FirstOrDefaultAsync(t => t.Id == request.Id , cancellationToken);

        if (task == null)
            throw new NotFoundException($"Task with ID {request.Id} not found.");

        _context.ToDoTasks.Remove(task);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
