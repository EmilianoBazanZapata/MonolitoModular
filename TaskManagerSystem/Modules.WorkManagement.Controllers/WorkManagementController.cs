using MediatR;
using Microsoft.AspNetCore.Mvc;
using Modules.WorkManagement.Application.Features.Projects.Commands.CreateProject;
using Modules.WorkManagement.Application.Features.Projects.Commands.DeleteProject;
using Modules.WorkManagement.Application.Features.Projects.Commands.UpdateProject;
using Modules.WorkManagement.Application.Features.Projects.Queries.GetAllProjects;
using Modules.WorkManagement.Application.Features.Projects.Queries.GetProjectById;
using TaskManager.Shared.Core.Helpers;

namespace Modules.WorkManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController(IMediator _mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectCommand command)
    {
        var projectId = await _mediator.Send(command);
        return SuccessResponseHelper.CreateResponse(projectId, "Project created successfully.");
    }
    
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProjectCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllProjectsQuery());
        return Ok(result);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetProjectByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteProjectCommand(id));
        return NoContent();
    }
}