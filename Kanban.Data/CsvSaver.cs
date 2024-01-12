using System.Text;
using Kanban.Contract;
using Kanban.Entity;

namespace Kanban.Data;

public class CsvSaver
    : IWorkItemSaver
{
    public SaveResponse Save(IEnumerable<WorkItem> workItems)
    {
        try
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, "WorkItemData.csv");
            StringBuilder stringBuilder = new();
            foreach (var wi in workItems)
            {
                var line = wi.ToString();
                stringBuilder.AppendLine(line);
            }
            File.WriteAllText(filePath, stringBuilder.ToString());
            return new SaveResponse
            {
                IsSuccess = true,
                Exception = null,
                Message = "Görevler listesi WorkItemData.csv dosyasına kaydedildi.",
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