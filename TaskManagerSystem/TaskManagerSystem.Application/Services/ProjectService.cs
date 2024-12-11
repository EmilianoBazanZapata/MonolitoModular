using TaskManagerSystem.Application.DTOs.Project;
using TaskManagerSystem.Core.Entities;
using TaskManagerSystem.Core.Exceptions;
using TaskManagerSystem.Core.Interfaces;

namespace TaskManagerSystem.Application.Services;

public class ProjectService(IGenericRepository<Project> projectRepository)
{
    public async Task<IEnumerable<GetProjectDto>> GetAllProjectsAsync()
    {
        var projects = await projectRepository.GetAllAsync();
        return projects.Select(project => new GetProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            CreatedAt = project.CreatedAt,
            UpdatedAt = project.UpdatedAt == DateTime.MinValue ? (DateTime?)null : project.UpdatedAt
        });
    }

    public async Task<GetProjectDto?> GetProjectByIdAsync(int id)
    {
        var project = await projectRepository.GetByIdAsync(id);
        if (project == null) throw new NotFoundException($"The project with Id: {id} not found.");

        return new GetProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            CreatedAt = project.CreatedAt,
            UpdatedAt = project.UpdatedAt == DateTime.MinValue ? (DateTime?)null : project.UpdatedAt
        };
    }

    public async Task<Project> AddProjectAsync(CreateProjectDto projectDto)
    {
        var project = new Project { Name = projectDto.Name, CreatedAt = DateTime.UtcNow.Date};

        await projectRepository.AddAsync(project);

        return project;
    }

    public async Task UpdateProjectAsync(int id, UpdateProjectDto projectDto)
    {
        var project = await projectRepository.GetByIdAsync(id);
        
        if (project == null) throw new NotFoundException($"The project with Id: {id} not found.");

        project.Name = projectDto.Name;
        project.UpdatedAt = DateTime.UtcNow.Date;

        await projectRepository.UpdateAsync(project);
    }

    public async Task DeleteProjectAsync(int id)
    {
        var project = await projectRepository.GetByIdAsync(id);

        if (project == null) throw new NotFoundException("Project not found.");

        await projectRepository.DeleteAsync(project.Id);
    }
}