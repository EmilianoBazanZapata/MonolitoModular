using MediatR;
using Microsoft.AspNetCore.Identity;
using Modules.WorkManagement.Core.DTOs.Task;
using TaskManager.Shared.Core.Exceptions;

namespace Modules.Users.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler(UserManager<IdentityUser> userManager) : IRequestHandler<CreateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userExisting = await userManager.FindByEmailAsync(request.User.Email);

        if (userExisting != null)
            throw new ConflictException($"The Email: {request.User.Email} already registered");
        
        var user = new IdentityUser { UserName = request.User.UserName, Email = request.User.Email };
        
        var result = await userManager.CreateAsync(user, request.User.Password);

        if (!result.Succeeded)
            throw new BadRequestException(result.Errors.FirstOrDefault()?.Description ?? "Failed to create user.");

        return new UserDto(user.Id, user.UserName, user.Email);
    }
}