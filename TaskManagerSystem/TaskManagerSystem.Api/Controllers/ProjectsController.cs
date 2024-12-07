using Microsoft.AspNetCore.Mvc;
using TaskManagerSystem.Api.Helpers;
using TaskManagerSystem.Application.DTOs;
using TaskManagerSystem.Application.Services;

namespace TaskManagerSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController(ProjectService projectService) : ControllerBase
{
    // GET: api/projects
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projects = await projectService.GetAllProjectsAsync();
        return SuccessResponseHelper.CreateResponse(projects, "Projects retrieved successfully.");
    }

    // GET: api/projects/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var project = await projectService.GetProjectByIdAsync(id);
        return SuccessResponseHelper.CreateResponse(project, "Project retrieved successfully.");
    }

    // POST: api/projects
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProjectDto projectDto)
    {
        var project = await projectService.AddProjectAsync(projectDto);
        return SuccessResponseHelper.CreateResponse(project, "Project created successfully.");
    }

    // PUT: api/projects/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProjectDto projectDto)
    {
        await projectService.UpdateProjectAsync(id, projectDto);
        return SuccessResponseHelper.CreateResponse<object>(null, "Project updated successfully.");
    }

    // DELETE: api/projects/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await projectService.DeleteProjectAsync(id);
        return SuccessResponseHelper.CreateResponse<object>(null, "Project deleted successfully.");
    }
}