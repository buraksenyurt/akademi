using System.Text.Json;
using Kanban.Contract;

namespace Kanban.Data;
public class JsonLoader
    : ITaskLoader
{
    public LoadResponse GetTasks()
    {
        try
        {
            var sourcePath = Path.Combine(Environment.CurrentDirectory, "TaskData.json");
            var tasks = JsonSerializer.Deserialize<List<Entity.Task>>(sourcePath);
            return new LoadResponse
            {
                IsSuccess = true,
                Message = "Task listesi CSV dosyadan yüklendi.",
                Exception = null,
                LoadedObjectCount = tasks.Count,
                Tasks = tasks
            };
        }
        catch (Exception excp)
        {
            return new LoadResponse
            {
                IsSuccess = false,
                Message = excp.Message,
                Exception = excp,
                LoadedObjectCount = 0,
                Tasks = null
            };
        }
    }
}