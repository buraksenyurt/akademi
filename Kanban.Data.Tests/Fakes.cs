using Kanban.Contract;
using Kanban.Entity;

namespace Kanban.Data.Tests;
/*
    Bu birim test sınıfındaki TaskManager nesneleri örneklenirken ihtiyaç duyulan Task listesi için
    sahte bir ITaskLoader implementasyonu kullanmaktayız. Bu sayede task listesini sanki fiziki bir dosyadan 
    okumuşuz gibi nesneyi başlatma şansına sahip oluyoruz.
*/

public class FakeTaskLoader
    : ITaskLoader
{
    public LoadResponse GetTasks()
    {
        var tasks = new List<Entity.Task>{
                new(null)
                {
                    Title = "Ara sınav için hazırlık yap",
                    Duration = 3,
                    DurationType = DurationType.Hour,
                    TaskSize = TaskSize.M,
                },
                new(null)
                {
                    Title = "Odayı temizle.",
                    Duration = 1,
                    DurationType = DurationType.Hour,
                    TaskSize = TaskSize.S
                }
        };
        return new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Task listesi başarıyla yüklendi",
            LoadedObjectCount = tasks.Count,
            Tasks = tasks
        };
    }
}

/*
    Duruma göre ihtiyaç duyulan task listeleri farklılaştıkça buradaki Fake sınıfının sayısı da artabilir.
    Bu çok istemediğimiz bir durum. Bunun için Mock kütüphanelerinden yararlanılabilir.
*/

public class FakeTaskLoaderWithState
    : ITaskLoader
{
    public LoadResponse GetTasks()
    {
        var tasks = new List<Entity.Task>{
                new(null)
                {
                    Title = "Ara sınav için hazırlık yap",
                    Duration = 3,
                    DurationType = DurationType.Hour,
                    TaskSize = TaskSize.M,
                },
                new(null)
                {
                    Title = "Odayı temizle.",
                    Duration = 1,
                    DurationType = DurationType.Hour,
                    TaskSize = TaskSize.S
                }
        };
        tasks[0].ChangeState();
        return new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Task listesi başarıyla yüklendi",
            LoadedObjectCount = tasks.Count,
            Tasks = tasks
        };
    }
}

public class FakeTaskSaver
    : ITaskSaver
{
    public SaveResponse Save(IEnumerable<Entity.Task> tasks)
    {
        return new SaveResponse
        {
            IsSuccess = true,
            Exception = new Exception(),
            Message = "Task listesi TaskData.csv dosyasına kaydedildi.",
            SavedObjectCount = tasks.Count()
        };
    }
}

public class FakeTaskSaverInFail
    : ITaskSaver
{
    public SaveResponse Save(IEnumerable<Entity.Task> tasks)
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