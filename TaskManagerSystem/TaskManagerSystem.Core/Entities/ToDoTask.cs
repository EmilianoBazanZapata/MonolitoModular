using TaskStatus = TaskManagerSystem.Core.Enums.TaskStatus;

namespace TaskManagerSystem.Core.Entities;

public class ToDoTask : BaseEntity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime DueDate { get; set; } 
    public TaskStatus Status { get; set; }
    
    public int ProjectId { get; set; }
    public Project? Project { get; set; }
    
    public string? AssignedUserId { get; set; }
    public User? AssignedUser { get; set; }
}