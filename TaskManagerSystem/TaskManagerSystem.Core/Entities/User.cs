using Microsoft.AspNetCore.Identity;

namespace TaskManagerSystem.Core.Entities;

public class User : IdentityUser
{
    public ICollection<ToDoTask> Tasks { get; set; } = new List<ToDoTask>();
}