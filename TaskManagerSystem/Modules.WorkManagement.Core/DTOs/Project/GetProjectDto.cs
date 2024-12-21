namespace Modules.WorkManagement.Core.DTOs.Project;

public class GetProjectDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}