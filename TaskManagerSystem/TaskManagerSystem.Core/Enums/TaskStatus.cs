using System.ComponentModel;

namespace TaskManagerSystem.Core.Enums;

public enum TaskStatus
{
    [Description("Pending")]
    Pending = 1,

    [Description("In Progress")]
    InProgress = 2,

    [Description("Completed")]
    Completed = 3
}