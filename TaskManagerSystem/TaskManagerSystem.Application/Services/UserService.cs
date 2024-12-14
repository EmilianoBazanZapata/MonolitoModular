using Microsoft.AspNetCore.Identity;
using TaskManagerSystem.Core.Exceptions;
using Mapster;
using TaskManagerSystem.Application.DTOs.User;
using TaskManagerSystem.Core.Entities;
using TaskManagerSystem.Core.Interfaces;

namespace TaskManagerSystem.Application.Services;

public class UserService(UserManager<User> userManager,  
                         RoleManager<IdentityRole> roleManager)
{
    public IQueryable<GetUserDto> GetAllUsers() => userManager.Users.ProjectToType<GetUserDto>();

    public async Task<GetUserDto> GetUserByIdAsync(string id)
    {
        var user = await ValidateExistingUser(id);

        return user.Adapt<GetUserDto>();
    }

    public async Task UpdateUserAsync(string id, UpdateUserDto updateUserDto)
    {
        var user = await ValidateExistingUser(id);

        updateUserDto.Adapt(user);
        
        var result = await userManager.UpdateAsync(user);
        if (!result.Succeeded)
            throw new BadRequestException(result.Errors.FirstOrDefault()?.Description ?? "Failed to update user.");
    }

    public async Task DeleteUserAsync(string id)
    {
        var user = await ValidateExistingUser(id);

        var result = await userManager.DeleteAsync(user);
        
        if (!result.Succeeded)
            throw new BadRequestException(result.Errors.FirstOrDefault()?.Description ?? "Failed to delete user.");
    }

    public async Task AssignRoleToUserAsync(AssignRoleDto assignRoleDto)
    {
        var user = await userManager.FindByIdAsync(assignRoleDto.UserId) ?? 
                   throw new NotFoundException($"User with ID {assignRoleDto.UserId} not found.");

        var role = await roleManager.FindByIdAsync(assignRoleDto.RoleId) ??
                   throw new BadRequestException($"Role with Id'{assignRoleDto.RoleId}' does not exist.");

        var result = await userManager.AddToRoleAsync(user, role.Name);
        
        if (!result.Succeeded)
            throw new BadRequestException(result.Errors.FirstOrDefault()?.Description ?? "Failed to assign role.");
    }

    private async Task<User> ValidateExistingUser(string id)
    {
        var user = await userManager.FindByIdAsync(id) ?? throw new NotFoundException($"User with ID {id} not found.");

        return user;
    }
}
