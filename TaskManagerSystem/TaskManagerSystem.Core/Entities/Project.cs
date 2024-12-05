namespace TaskManagerSystem.Core.Entities;

public class Project : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    
    public List<Task> Tasks { get; set; }
}