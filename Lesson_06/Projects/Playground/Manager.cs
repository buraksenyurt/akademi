namespace Playground;

public class Manager
{
    private readonly List<WorkItem> _workItems;
    public Manager()
    {
        _workItems = new List<WorkItem>();
    }
    public void Seed()
    {
        #region Load dummy work items

        _workItems.Add(new WorkItem
        {
            Title = "Final sınavı için şimdiden hazırlık yap.",
            Duration = 3,
            DurationType = Duration.Hour,
            Size = Size.M,
            Priority = Priority.High,
        });
        _workItems.Add(new WorkItem
        {
            Title = "Odayı temizle.",
            Duration = 5,
            DurationType = Duration.Hour,
            Size = Size.S
        });
        _workItems.Add(new WorkItem
        {
            Title = "İzmir'deki üniversite arkadaşını ziyaret et.",
            Duration = 2,
            DurationType = Duration.Day,
            Size = Size.L
        });
        _workItems.Add(new WorkItem
        {
            Title = "Oyun programlamada kullanılan matematik teoremlerin özetini çıkar",
            Duration = 3,
            DurationType = Duration.Month,
            Size = Size.L
        });
        _workItems.Add(new WorkItem
        {
            Title = "Kahve stoklarımız tükendi. Kahve alalım.",
            Duration = 2,
            DurationType = Duration.Hour,
            Size = Size.S,
            Priority = Priority.High,
        });
        _workItems.Add(new WorkItem
        {
            Title = "TodoApp uygulamasındaki kodları gözden geçir. Refactoring.",
            Duration = 1,
            DurationType = Duration.Day,
            Size = Size.S,
        });
        _workItems.Add(new WorkItem
        {
            Title = "Cross yorucuydu. Bisiklet epeyce kirlendi. Bazı parçalarını bakımdan geçirmek gerekir. Ve Temizlenmeli!",
            Duration = 1,
            DurationType = Duration.Day,
            Size = Size.M,
        });
        _workItems.Add(new WorkItem
        {
            Title = "Tadil edilmesi gereken birkaç parça kıyafet var. Onları onar.",
            Duration = 3,
            DurationType = Duration.Day,
            Size = Size.L,
        });
        _workItems.Add(new WorkItem
        {
            Title = "İdeal kiloya inmek doktor kontrolünde diyet uygula.",
            Duration = 6,
            DurationType = Duration.Month,
            Size = Size.XL,
        });
        _workItems.Add(new WorkItem
        {
            Title = "Oda arkadaşına programlama dili öğretmeye başla.",
            Duration = 7,
            DurationType = Duration.Day,
            Size = Size.L,
            Priority = Priority.High
        });

        #endregion
    }
    public Guid Add(WorkItem newWorkItem)
    {
        _workItems.Add(newWorkItem);
        return newWorkItem.Id;
    }
    public WorkItem GetWorkItem(Guid id)
    {
        return _workItems.SingleOrDefault(t => t.Id == id);
    }
    public int GetCount(State state)
    {
        return _workItems.Count(t => t.State == state);
    }
    public List<WorkItem> GetWorkItems()
    {
        return _workItems;
    }
    public List<WorkItem> GetWorkItems(State state)
    {
        return _workItems.Where(t => t.State == state).ToList();
    }

    // Bir metoda parametre olarak fonksiyon geçebilmek
    // GetWorkItems metodunun aşırı yüklenmiş(overload) aşağıdaki versiyonu
    // SearchWorkItem delegate tipinden parametreler alır.
    // Bu delegate türü bir metodu işaret edebildiğinde GetWorkItems metoduna
    // parametre olarak fonksiyon taşıyabiliriz.
    public List<WorkItem> GetWorkItems(SearchWorkItem searchWorkItem)
    {
        // İçerideki tüm listeyi dolaş
        var result = new List<WorkItem>();
        foreach (var wi in _workItems)
        {
            // Parametre olarak gelen fonksiyonu o anki wi nesne örneği ile çalıştır            
            if (searchWorkItem(wi))
            {
                // true dönüyorsa result listesine ekle
                result.Add(wi);
            }
        }

        // elde edilen result listesini geri döndür
        return result;
    }
}

// Aşağıda bir temsilci tipi yer alıyor. Bir temsili ile tarif ettiği şablona uyan metodları
// çalışma zamanında referans edebiliriz.
// Aşağıdaki tarifte WorkItem türünden parametre alıp bool değer döndüren metotları işaret edebileceğimizi belirttik.
public delegate bool SearchWorkItem(WorkItem workItem);