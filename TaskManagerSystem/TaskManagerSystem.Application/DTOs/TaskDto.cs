using TaskStatus = TaskManagerSystem.Core.Enums.TaskStatus;

namespace TaskManagerSystem.Application.DTOs;

public class TaskDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public TaskStatus Status { get; set; }
    public int ProjectId { get; set; }
}