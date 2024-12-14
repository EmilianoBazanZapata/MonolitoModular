using Microsoft.AspNetCore.Mvc;
using TaskManagerSystem.Api.Helpers;
using TaskManagerSystem.Application.DTOs.Token;
using TaskManagerSystem.Application.DTOs.User;
using TaskManagerSystem.Application.Services;

namespace TaskManagerSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(AuthService authService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token = await authService.LoginAsync(loginDto);
            return Ok(new { Token = token });
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Create([FromBody] CreateUserDto createUserDto)
        {
            var user = await authService.CreateUserAsync(createUserDto);
            return SuccessResponseHelper.CreateResponse(user, "User created successfully.");
        }
    }
}