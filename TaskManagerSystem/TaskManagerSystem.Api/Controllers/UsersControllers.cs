using Microsoft.AspNetCore.Mvc;
using TaskManagerSystem.Application.DTOs;
using TaskManagerSystem.Application.Services;
using TaskManagerSystem.Api.Helpers;

namespace TaskManagerSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(UserService userService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = userService.GetAllUsers();
        return SuccessResponseHelper.CreateResponse(users, "Users retrieved successfully.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var user = await userService.GetUserByIdAsync(id);
        return SuccessResponseHelper.CreateResponse(user, "User retrieved successfully.");
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDto createUserDto)
    {
        var user = await userService.CreateUserAsync(createUserDto);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, SuccessResponseHelper.CreateResponse(user, "User created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] UpdateUserDto updateUserDto)
    {
        await userService.UpdateUserAsync(id, updateUserDto);
        return SuccessResponseHelper.CreateResponse<object>(null, "User updated successfully.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await userService.DeleteUserAsync(id);
        return SuccessResponseHelper.CreateResponse<object>(null, "User deleted successfully.");
    }

    [HttpPost("{id}/roles")]
    public async Task<IActionResult> AssignRole(string id, [FromBody] AssignRoleDto assignRoleDto)
    {
        await userService.AssignRoleToUserAsync(id, assignRoleDto);
        return SuccessResponseHelper.CreateResponse<object>(null, $"Role '{assignRoleDto.Role}' assigned to user.");
    }
}
