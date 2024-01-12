using Kanban.Contract;
using Kanban.Entity;

namespace Kanban;

/*
    CsvLoader varsayılan olarak yapılacakları bir dosyadan okuma görevini işler.
    Bu CSV uzantılı bir dosyadır.
    CsvLoader sınıfı IWorkItemLoader interface'inden türediği için bu arayüz tipinde belirtilen tüm metotları uygulamak zorundadır.
*/
public class CsvLoader
    : IWorkItemLoader
{
    public LoadResponse GetWorkItems()
    {
        var workItems = new List<WorkItem>();
        try
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, "WorkItemData.csv");
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var columns = line.Split('|');
                WorkItem newWorkItem = new(Guid.Parse(columns[0]))
                {
                    Title = columns[1],
                    WorkItemSize = (WorkItemSize)Enum.Parse(typeof(WorkItemSize), columns[2]),
                    Duration = Convert.ToByte(columns[3]),
                    DurationType = Enum.Parse<DurationType>(columns[4]),
                    State = Enum.Parse<WorkItemState>(columns[5])
                };
                workItems.Add(newWorkItem);
            }
            return new LoadResponse
            {
                IsSuccess = true,
                Message = "Görevler listesi CSV dosyadan yüklendi.",
                Exception = null,
                LoadedObjectCount = workItems.Count,
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