using Modules.Shared.Entities;
using TaskManager.Shared.Core.Entities;

namespace Modules.WorkManagement.Core.Entities;

public class Project : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public List<ToDoTask> Tasks { get; set; }
}