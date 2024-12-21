using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.User.Users.Abstractions;
using Modules.WorkManagement.Core.Abstractions;
using TaskManager.Shared.Core.Exceptions;

namespace Modules.WorkManagement.Application.Features.Tasks.Commands.UpdateTask;

public class UpdateTaskCommandHandler(IWorkManagementDbContext _context) : IRequestHandler<UpdateTaskCommand, int>
{
    public async Task<int> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var taskExisting = await _context.ToDoTasks.AnyAsync(p => p.Name == request.Name && 
                                                                          p.ProjectId == request.ProjectId &&
                                                                          p.Id != request.Id, cancellationToken);
        
        if (taskExisting)
            throw new ConflictException($"The Task {request.Name} already registered.");
        
        var task = await _context.ToDoTasks.FirstOrDefaultAsync(t=> t.Id == request.Id , cancellationToken);

        if (task == null)
            throw new NotFoundException($"Task with ID {request.Id} not found.");

        task.Name = request.Name;
        task.Description = request.Description;
        task.DueDate = request.DueDate;
        task.UpdatedAt = DateTime.UtcNow;
        task.ProjectId = request.ProjectId;

        await _context.SaveChangesAsync(cancellationToken);
        
        return task.Id;
    }
}