namespace Kanban.Entity;

public class Task
{
    int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public Duration DurationType { get; set; }
    public byte Duration { get; set; }
    public TaskSize TaskSize { get; set; }
    private TaskState _state;
    public TaskState State
    {
        get
        {
            return _state;
        }
    }
}