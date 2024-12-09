using Microsoft.AspNetCore.Identity;
using TaskManagerSystem.Application.DTOs;
using TaskManagerSystem.Core.Exceptions;
using Mapster;

namespace TaskManagerSystem.Application.Services;

public class UserService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
{
    public IQueryable<UserDto> GetAllUsers()
    {
        return userManager.Users.ProjectToType<UserDto>();
    }

    public async Task<UserDto> GetUserByIdAsync(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user == null)
            throw new NotFoundException($"User with ID {id} not found.");

        return user.Adapt<UserDto>();
    }

    public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
    {
        var user = createUserDto.Adapt<IdentityUser>();

        var result = await userManager.CreateAsync(user, createUserDto.Password);
        if (!result.Succeeded)
            throw new BadRequestException(result.Errors.FirstOrDefault()?.Description ?? "Failed to create user.");

        return user.Adapt<UserDto>();
    }

    public async Task UpdateUserAsync(string id, UpdateUserDto updateUserDto)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user == null)
            throw new NotFoundException($"User with ID {id} not found.");

        updateUserDto.Adapt(user);

        var result = await userManager.UpdateAsync(user);
        if (!result.Succeeded)
            throw new BadRequestException(result.Errors.FirstOrDefault()?.Description ?? "Failed to update user.");
    }

    public async Task DeleteUserAsync(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user == null)
            throw new NotFoundException($"User with ID {id} not found.");

        var result = await userManager.DeleteAsync(user);
        if (!result.Succeeded)
            throw new BadRequestException(result.Errors.FirstOrDefault()?.Description ?? "Failed to delete user.");
    }

    public async Task AssignRoleToUserAsync(string id, AssignRoleDto assignRoleDto)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user == null)
            throw new NotFoundException($"User with ID {id} not found.");

        var roleExists = await roleManager.RoleExistsAsync(assignRoleDto.Role);
        if (!roleExists)
            throw new BadRequestException($"Role '{assignRoleDto.Role}' does not exist.");

        var result = await userManager.AddToRoleAsync(user, assignRoleDto.Role);
        if (!result.Succeeded)
            throw new BadRequestException(result.Errors.FirstOrDefault()?.Description ?? "Failed to assign role.");
    }
}
