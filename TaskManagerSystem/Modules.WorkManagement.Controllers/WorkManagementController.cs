using Microsoft.AspNetCore.Mvc;

namespace Modules.WorkManagement.Controllers;

[ApiController]
[Route("/api/catalog/[controller]")]
public class WorkManagementController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok();
    }
}