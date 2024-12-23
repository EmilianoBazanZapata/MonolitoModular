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

namespace Modules.Users.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllUsersQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await mediator.Send(new GetUserByIdQuery(id));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDto userDto)
    {
        var result = await mediator.Send(new CreateUserCommand(userDto));
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] UpdateUserDto userDto)
    {
        await mediator.Send(new UpdateUserCommand(id, userDto));
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await mediator.Send(new DeleteUserCommand(id));
        return NoContent();
    }
}