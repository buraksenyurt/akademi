using System.Text.Json;
using Kanban.Contract;
using Kanban.Entity;

namespace Kanban.Data;

public class JsonSaver
    : IWorkItemSaver
{
    public SaveResponse Save(IEnumerable<WorkItem> workItems)
    {
        try
        {
            var targetPath = Path.Combine(Environment.CurrentDirectory, "WorkItemData.json");
            Console.WriteLine($"İçerik {targetPath} dosyasına kaydedilecek");
            var content = JsonSerializer.Serialize(workItems, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(targetPath, content);
            return new SaveResponse
            {
                IsSuccess = true,
                Exception = null,
                Message = "Görev listesi JSON formatında kaydedildi",
                SavedObjectCount = workItems.Count()
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