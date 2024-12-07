using TaskManagerSystem.Application.DTOs;
using TaskManagerSystem.Core.Entities;
using TaskManagerSystem.Core.Exceptions;
using TaskManagerSystem.Core.Interfaces;

namespace TaskManagerSystem.Application.Services;

public class ProjectService(IGenericRepository<Project> projectRepository)
{
    public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
    {
        var projects = await projectRepository.GetAllAsync();
        return projects.Select(project => new ProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            CreatedAt = project.CreatedAt,
            UpdatedAt = project.UpdatedAt
        });
    }

    public async Task<ProjectDto?> GetProjectByIdAsync(int id)
    {
        var project = await projectRepository.GetByIdAsync(id);
        if (project == null) return null;

        return new ProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            CreatedAt = project.CreatedAt,
            UpdatedAt = project.UpdatedAt
        };
    }

    public async Task<Project> AddProjectAsync(ProjectDto projectDto)
    {
        var project = new Project
        {
            Name = projectDto.Name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await projectRepository.AddAsync(project);

        return project;
    }

    public async Task UpdateProjectAsync(int id, ProjectDto projectDto)
    {
        var project = await projectRepository.GetByIdAsync(id);
        if (project == null) throw new NotFoundException("Project not found.");

        project.Name = projectDto.Name;
        project.UpdatedAt = DateTime.UtcNow;

        await projectRepository.UpdateAsync(project);
    }

    public async Task DeleteProjectAsync(int id)
    {
        var project = await projectRepository.GetByIdAsync(id);

        if (project == null) throw new NotFoundException("Project not found.");

        await projectRepository.DeleteAsync(project.Id);
    }
}