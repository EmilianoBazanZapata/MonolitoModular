using Modules.Shared.Entities;

namespace Modules.WorkManagement.Core.Entities;

public class Project : BaseEntity
{
    public string Name { get; set; }
    
    public List<ToDoTask> Tasks { get; set; }
}