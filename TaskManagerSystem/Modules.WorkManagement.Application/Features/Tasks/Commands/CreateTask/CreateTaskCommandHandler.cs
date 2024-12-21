using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.User.Users.Abstractions;
using Modules.WorkManagement.Core.Abstractions;
using Modules.WorkManagement.Core.Entities;
using TaskManager.Shared.Core.Exceptions;

namespace Modules.WorkManagement.Application.Features.Tasks.Commands.CreateTask;

public class CreateTaskCommandHandler(IWorkManagementDbContext _context) : IRequestHandler<CreateTaskCommand, int>
{
    public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var taskExisting = await _context.ToDoTasks.AnyAsync(p => p.Name == request.Name, cancellationToken);

        if (taskExisting)
            throw new ConflictException($"The Task {request.Name} already registered.");
        
        var task = new ToDoTask
        {
            Name = request.Name,
            Description = request.Description,
            ProjectId = request.ProjectId,
            DueDate = request.DueDate,
            CreatedAt = DateTime.UtcNow
        };

        _context.ToDoTasks.Add(task);
        await _context.SaveChangesAsync(cancellationToken);

        return task.Id;
    }
}
