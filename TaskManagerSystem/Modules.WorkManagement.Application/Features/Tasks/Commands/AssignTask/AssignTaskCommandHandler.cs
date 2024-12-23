using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modules.WorkManagement.Core.Abstractions;
using TaskManager.Shared.Core.Exceptions;

namespace Modules.WorkManagement.Application.Features.Tasks.Commands.AssignTask;

public class AssignTaskCommandHandler(IWorkManagementDbContext _context, 
                                      UserManager<IdentityUser> _userManager) : IRequestHandler<AssignTaskCommand, Unit>
{
    public async Task<Unit> Handle(AssignTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _context.ToDoTasks.FirstOrDefaultAsync(t => t.Id == request.TaskId, cancellationToken);

        if (task == null)
            throw new NotFoundException("Task not found");

        var user = await _userManager.FindByIdAsync(request.UserId);

        if (user == null)
            throw new NotFoundException("User not found");

        task.AssignedUserId = request.UserId;

        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}