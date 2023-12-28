using Kanban.Contracts;

namespace Kanban.Data;
public class JsonLoader
    : ITaskLoader
{
    public IEnumerable<Entity.Task> GetTasks(string fileName)
    {
        throw new NotImplementedException();
    }
}