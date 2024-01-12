using Kanban.Entity;

namespace Kanban.Contract;
/*
    Interface tipleri daha çok nesne bağımlılıklarını çözümlemek,
    çok biçimliliği karşılamak, plug-in tabanlı kodlama yapmak vb senaryolarda kullanılır.

    Normal iş yapan metotlar veya alanlar içeremezler. 
    Bir interface, onu uygulayan asıl nesneler için mutlaka yazılması gereken üyelerin tanımını içerir.

    Sistemdeki bütün interface türleri büyük I harfi ile başlar ve bu bir isimlendirme standardıdır.

    Interface türünün önemli özelliklerinden birisi, kendisini implemente eden nesne örneklerini taşıyabilmesidir.
    Bu duruma nesne yönelimli dillerde çok biçimlilik (Polymorphyszm) adı da verilir.
*/
public interface IWorkItemLoader
{
    LoadResponse GetWorkItems(); // Bu interface tipini uygulayanlar GetWorkItems isimli metodu ezmek(yazmak) zorundadır
}

public class LoadResponse
{
    public bool IsSuccess { get; set; }
    public Exception? Exception { get; set; }
    public string Message { get; set; } = string.Empty;
    public int LoadedObjectCount { get; set; }
    public IEnumerable<WorkItem>? WorkItems;
}