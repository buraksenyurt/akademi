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
            var content = File.ReadAllText(sourcePath);
            var workItemDtos = JsonSerializer.Deserialize<List<WorkItemDto>>(content);
            /*
                JSON İçeriğindeki bilgiler doğrudan WorkItem tipine çevrilemeyecektir. 
                Serileşen JSON içeriğinde enum değerleri sayısal olarak aktarılır. 
                Dolayısıyla asıl WorkItem nesnesine geçiş için bir ara tipe ihtiyacımız var.
                Dosya içeriğin WorkItemDto tipinden nesne örneklerine çevirdikten sonra
                bunları WorkItem türüne dönüştürebiliriz.
                DTO, Data Transfer Objects anlamına gelmektedir. Buradaki süreç genelde Mapper araçları ile halledelir.
                Örneğin AutoMapper gibi.
            */
            var workItems = new List<WorkItem>();
            foreach (var dto in workItemDtos)
            {
                workItems.Add(new WorkItem(Guid.Parse(dto.Id))
                {
                    Title = dto.Title,
                    Duration = Convert.ToByte(dto.Duration),
                    DurationType = (DurationType)Enum.Parse(typeof(DurationType), dto.DurationType.ToString()),
                    State = (WorkItemState)Enum.Parse(typeof(WorkItemState), dto.State.ToString()),
                    WorkItemSize = (WorkItemSize)Enum.Parse(typeof(WorkItemSize), dto.WorkItemSize.ToString()),
                });
            }

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
            Console.WriteLine(excp.Message);
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