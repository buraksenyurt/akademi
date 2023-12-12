namespace Kanban.Runtime;

public class NewTaskAddedEventArgs
{
    public Guid TaskId { get; set; }
    public DateTime Time { get; set; } = DateTime.Now;
}

public delegate void NewTaskAddedEventHandler(Entity.Task source, NewTaskAddedEventArgs eventArgs);