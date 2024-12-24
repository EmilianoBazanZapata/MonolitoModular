using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modules.User.Users.DTOs;
using Modules.Users.Application.Features.Users.Commands.CreateUser;
using Modules.Users.Application.Features.Users.Commands.DeleteUser;
using Modules.Users.Application.Features.Users.Commands.UpdateUser;
using Modules.Users.Application.Features.Users.Queries.GetAllUsersQuery;
using Modules.Users.Application.Features.Users.Queries.GetUserByIdQuery;
using Modules.WorkManagement.Core.DTOs;
using Modules.WorkManagement.Core.DTOs.Task;
using TaskManager.Shared.Core.Helpers;

namespace Modules.Users.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllUsersQuery());
        return SuccessResponseHelper.CreateResponse(result, "Users retrieved successfully.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await mediator.Send(new GetUserByIdQuery(id));
        return SuccessResponseHelper.CreateResponse(result);
    }
    

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] UpdateUserDto userDto)
    {
        await mediator.Send(new UpdateUserCommand(id, userDto));
        return SuccessResponseHelper.CreateResponse("User updated successfully.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await mediator.Send(new DeleteUserCommand(id));
        return SuccessResponseHelper.CreateResponse("User deleted successfully.");
    }
}