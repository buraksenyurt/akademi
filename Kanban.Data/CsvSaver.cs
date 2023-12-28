using System.Text;
using Kanban.Contract;

namespace Kanban.Data;

public class CsvSaver
    : ITaskSaver
{
    public SaveResponse Save(IEnumerable<Entity.Task> tasks)
    {
        try
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, "TaskData.csv");
            StringBuilder stringBuilder = new();
            foreach (var task in tasks)
            {
                var line = task.ToString();
                stringBuilder.AppendLine(line);
            }
            File.WriteAllText(filePath, stringBuilder.ToString());
            return new SaveResponse
            {
                IsSuccess = true,
                Exception = null,
                Message = "Task listesi TaskData.csv dosyasına kaydedildi.",
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