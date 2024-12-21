namespace Modules.WorkManagement.Core.DTOs.Project;

public record GetProjectDto(int Id, string Name, string Description, DateTime CreatedAt, DateTime? UpdatedAt);