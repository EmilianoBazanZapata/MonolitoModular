using MediatR;
using Microsoft.AspNetCore.Mvc;
using Modules.User.Users.DTOs;
using Modules.Users.Application.Features.Authorizations.Commands.LoginUser;
using Modules.Users.Application.Features.Users.Commands.CreateUser;
using TaskManager.Shared.Core.Helpers;

namespace Modules.Users.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var token = await mediator.Send(new LoginUserCommand(loginDto));
        return SuccessResponseHelper.CreateResponse(token,"User logged successfully.");
    }
    
    [HttpPost("signUp")]
    public async Task<IActionResult> Create([FromBody] CreateUserDto userDto)
    {
        var user = await mediator.Send(new CreateUserCommand(userDto));
        return SuccessResponseHelper.CreateResponse(user,"User created successfully.");
    }
}