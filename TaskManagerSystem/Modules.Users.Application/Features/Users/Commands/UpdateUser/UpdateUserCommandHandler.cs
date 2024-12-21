using MediatR;
using Microsoft.AspNetCore.Identity;
using Modules.User.Users.Entities;
using TaskManager.Shared.Core.Exceptions;

namespace Modules.Users.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler(UserManager<UserEntity> userManager) : IRequestHandler<UpdateUserCommand>
{
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id) ?? throw new NotFoundException("User not found.");
        
        var userWithSameEmail = await userManager.FindByEmailAsync(request.User.Email);
        
        if (userWithSameEmail != null && userWithSameEmail.Id != user.Id)
            throw new ConflictException($"The email '{request.User.Email}' is already registered by another user.");

        user.UserName = request.User.UserName;
        user.Email = request.User.Email;
        
        var result = await userManager.UpdateAsync(user);
        
        if (!result.Succeeded)
            throw new BadRequestException(result.Errors.FirstOrDefault()?.Description ?? "Failed to update user.");
    }
}
