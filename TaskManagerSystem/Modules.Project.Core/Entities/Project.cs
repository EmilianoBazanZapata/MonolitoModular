using Modules.Shared.Entities;
using Modules.Task.Core.Entities;

namespace Modules.Project.Core.Entities;

public class Project : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    
    public List<ToDoTask> Tasks { get; set; }
}