using System.Text.Json;
using Kanban.Contract;

namespace Kanban.Data;

public class JsonSaver
    : ITaskSaver
{
    public SaveResponse Save(IEnumerable<Entity.Task> tasks)
    {
        try
        {
            var targetPath = Path.Combine(Environment.CurrentDirectory, "TaskData.json");
            var content = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(targetPath, content);
            return new SaveResponse
            {
                IsSuccess = true,
                Exception = null,
                Message = "Görev listesi JSON formatında kaydedildi",
                SavedObjectCount = tasks.Count()
            };
        }
        catch (Exception excp)
        {
            return new SaveResponse
            {
                IsSuccess = false,
                Exception = excp,
                Message = "Kaydetme işlemi başarısız.",
                SavedObjectCount = 0
            };
        }
    }
}