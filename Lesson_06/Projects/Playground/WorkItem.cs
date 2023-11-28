namespace Playground;

public class WorkItem
{
    public Guid Id { get; } // Readonly
    public string Title { get; set; } = string.Empty;
    public Priority Priority { get; set; } = Priority.Standard;
    public Duration DurationType { get; set; }
    public byte Duration { get; set; }
    public Size Size { get; set; }
    private State _state;
    public State State
    {
        get
        {
            return _state;
        }
    }
    public WorkItem()
    {
        Id = Guid.NewGuid();
        _state = State.Todo;
    }

    public void ChangeState(bool failed = false)
    {
        if ((_state == State.Todo || _state == State.InProgress) && failed)
        {
            _state = State.Undone;
            return;
        }
        switch (_state)
        {
            case State.Todo:
                _state = State.InProgress;
                break;
            case State.InProgress:
            case State.Completed:
                _state = State.Completed;
                break;
        }
    }
}