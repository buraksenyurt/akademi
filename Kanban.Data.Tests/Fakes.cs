using Kanban.Contract;
using Kanban.Entity;

namespace Kanban.Data.Tests;
/*
    Bu birim test sınıfındaki WorkItemManager nesneleri örneklenirken ihtiyaç duyulan WorkItem listesi için
    sahte bir IWorkItemLoader implementasyonu kullanmaktayız. Bu sayede WorkItem listesini sanki fiziki bir dosyadan 
    okumuşuz gibi nesneyi başlatma şansına sahip oluyoruz.
*/

public class FakeWorkItemLoader
    : IWorkItemLoader
{
    public LoadResponse GetWorkItems()
    {
        var workItems = new List<WorkItem>{
                new(null)
                {
                    Title = "Ara sınav için hazırlık yap",
                    Duration = 3,
                    DurationType = DurationType.Hour,
                    WorkItemSize = WorkItemSize.M,
                },
                new(null)
                {
                    Title = "Odayı temizle.",
                    Duration = 1,
                    DurationType = DurationType.Hour,
                    WorkItemSize = WorkItemSize.S
                }
        };
        return new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Görev listesi başarıyla yüklendi",
            LoadedObjectCount = workItems.Count,
            WorkItems = workItems
        };
    }
}

/*
    Duruma göre ihtiyaç duyulan WorkItem listeleri farklılaştıkça buradaki Fake sınıfının sayısı da artabilir.
    Bu çok istemediğimiz bir durum. Bunun için Mock kütüphanelerinden yararlanılabilir.
*/

public class FakeWorkItemLoaderWithState
    : IWorkItemLoader
{
    public LoadResponse GetWorkItems()
    {
        var workItems = new List<WorkItem>{
                new(null)
                {
                    Title = "Ara sınav için hazırlık yap",
                    Duration = 3,
                    DurationType = DurationType.Hour,
                    WorkItemSize = WorkItemSize.M,
                },
                new(null)
                {
                    Title = "Odayı temizle.",
                    Duration = 1,
                    DurationType = DurationType.Hour,
                    WorkItemSize = WorkItemSize.S
                }
        };
        workItems[0].ChangeState();
        return new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Görev listesi başarıyla yüklendi",
            LoadedObjectCount = workItems.Count,
            WorkItems = workItems
        };
    }
}

public class FakeWorkItemSaver
    : IWorkItemSaver
{
    public SaveResponse Save(IEnumerable<WorkItem> workItems)
    {
        return new SaveResponse
        {
            IsSuccess = true,
            Exception = new Exception(),
            Message = "Görev listesi WorkItemData.csv dosyasına kaydedildi.",
            SavedObjectCount = workItems.Count()
        };
    }
}

public class FakeWorkItemSaverInFail
    : IWorkItemSaver
{
    public SaveResponse Save(IEnumerable<WorkItem> workItems)
    {
        return new SaveResponse
        {
            IsSuccess = false,
            Exception = new FileNotFoundException(),
            Message = "Kaydetme işlemi başarısız",
            SavedObjectCount = 0
        };
    }
}