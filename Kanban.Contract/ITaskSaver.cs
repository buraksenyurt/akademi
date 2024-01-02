namespace Kanban.Contract;
public interface ITaskSaver
{
    SaveResponse Save(IEnumerable<Entity.Task> tasks);
}
/*
    Kaydetme işlemi gibi operasyonlar geriye daha fazla bilgi dönebilir.
    İşlemin başarılı olup olmadığı, başarılı ise ek bilgi veya bir exception oluştuysa buna ait bilgiler dönülebilir.
*/

public class SaveResponse
{
    public bool IsSuccess { get; set; }
    public Exception? Exception { get; set; }
    public string Message { get; set; } = string.Empty;
    public int SavedObjectCount { get; set; }
}