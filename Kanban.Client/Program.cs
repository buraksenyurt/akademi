namespace Kanban.Client;

using Kanban.Data;
using Kanban.Entity;

class Program
{
    static void Main(string[] args)
    {
        var wi1 = new WorkItem(null)
        {
            Title = "Check the readme files and edit",
            WorkItemSize = WorkItemSize.S,
            DurationType = DurationType.Day,
            Duration = 1
        };
        var wi2 = new WorkItem(null)
        {
            Title = "Upgrade projects to .net 8",
            WorkItemSize = WorkItemSize.S,
            DurationType = DurationType.Day,
            Duration = 1
        };
        WorkItemManager manager = new WorkItemManager(new JsonLoader());

        var workItems = manager.GetWorkItems();
        foreach (var w in workItems)
        {
            Console.WriteLine(w.ToString());
        }

        manager.Add(wi1);
        manager.Add(wi2);
        var response = manager.Save(new JsonSaver());
        Console.WriteLine(
            "Kaydetme işlemi {0}. Toplamda {1} nesne kaydedildi",
            response.IsSuccess ? "Başarılı" : "Başarısız"
            , response.SavedObjectCount);
    }
}
