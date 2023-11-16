namespace Kanban.Entity;

public class Task
{
    public Guid Id { get; } // Readonly
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
    /*
        Bir Task nesne örneğinin diğerlerinden ayrışması noktasında benzersi Guid değerlerinden yararlanabilir.
        Id dışardına değiştirilemeyen ama bir Task örneği oluşturduğumuzda varsayılan yapıcı tarafından
        otmatik üretilen Guid türünden özelliktir.
    */
    public Task()
    {
        Id = Guid.NewGuid();
        //Console.WriteLine($"Task nesnesi için {Id} üretildi.");
        _state = TaskState.Todo;
    }

    public void ChangeState(bool failed = false)
    {
        if ((_state == TaskState.Todo || _state == TaskState.InProgress) && failed)
        {
            _state = TaskState.Undone;
            return;
        }
        switch (_state)
        {
            case TaskState.Todo:
                _state = TaskState.InProgress;
                break;
            case TaskState.InProgress:
            case TaskState.Completed:
                _state = TaskState.Completed;
                break;
        }
    }
}