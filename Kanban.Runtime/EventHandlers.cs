using Kanban.Entity;

namespace Kanban.Runtime;

public class WorkItemAddedEventArgs
{
    public Guid WorkItemId { get; set; }
    public DateTime Time { get; set; } = DateTime.Now;
}

public delegate void WorkItemAddedEventHandler(WorkItem source, WorkItemAddedEventArgs eventArgs);