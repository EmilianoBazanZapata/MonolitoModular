using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskManager.Shared.Core.Exceptions;

namespace Modules.Users.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler(UserManager<IdentityUser> userManager)
    : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id) ?? throw new NotFoundException("User not found.");
        await userManager.DeleteAsync(user);
    }
}