using System.Text.Json;
using Kanban.Contract;
using Kanban.Entity;

namespace Kanban.Data;
public class JsonLoader
    : IWorkItemLoader
{
    public LoadResponse GetWorkItems()
    {
        try
        {
            var sourcePath = Path.Combine(Environment.CurrentDirectory, "WorkItemData.json");
            var workItems = JsonSerializer.Deserialize<List<WorkItem>>(sourcePath);
            return new LoadResponse
            {
                IsSuccess = true,
                Message = "Görev listesi CSV dosyadan yüklendi.",
                Exception = null,
                LoadedObjectCount = workItems == null ? 0 : workItems.Count,
                WorkItems = workItems
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
                WorkItems = null
            };
        }
    }
}