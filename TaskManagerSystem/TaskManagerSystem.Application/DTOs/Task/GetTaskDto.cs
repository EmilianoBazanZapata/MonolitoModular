using TaskManagerSystem.Application.DTOs.User;

namespace TaskManagerSystem.Application.DTOs.Task;

public class GetTaskDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public TaskStatus Status { get; set; }
    public int ProjectId { get; set; }
    public GetUserDto AssignedUser { get; set; }
}