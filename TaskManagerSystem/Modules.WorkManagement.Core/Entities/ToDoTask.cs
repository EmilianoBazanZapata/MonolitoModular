using TaskManager.Shared.Core.Entities;

namespace Modules.WorkManagement.Core.Entities;

public class ToDoTask : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime DueDate { get; set; } 
    public TaskStatus Status { get; set; }
    public int ProjectId { get; set; }
    public Project? Project { get; set; }
    
    public string? AssignedUserId { get; set; }
}