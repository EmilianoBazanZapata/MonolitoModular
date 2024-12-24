using MediatR;
using Microsoft.AspNetCore.Identity;
using Modules.User.Users.DTOs;
using TaskManager.Shared.Core.Exceptions;

namespace Modules.Users.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler(UserManager<IdentityUser> _userManager, RoleManager<IdentityRole> _roleManager) : IRequestHandler<CreateUserCommand, LoggedUserDto>
{
    public async Task<LoggedUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userExisting = await _userManager.FindByEmailAsync(request.User.Email);

        if (userExisting != null)
            throw new ConflictException($"The Email: {request.User.Email} already registered");
        
        var user = new IdentityUser { UserName = request.User.UserName, Email = request.User.Email };
        
        var result = await _userManager.CreateAsync(user, request.User.Password);

        if (!result.Succeeded)
            throw new BadRequestException(result.Errors.FirstOrDefault()?.Description ?? "Failed to create user.");
        
        if (!await _roleManager.RoleExistsAsync("User"))
            throw new BadRequestException("The role 'User' dont exist.");

        var roleResult = await _userManager.AddToRoleAsync(user, "User");
        
        if (!roleResult.Succeeded)
            throw new BadRequestException(roleResult.Errors.FirstOrDefault()?.Description ?? "Failed to create user.");

        return new LoggedUserDto(user.Id, user.UserName, user.Email, "");
    }
}