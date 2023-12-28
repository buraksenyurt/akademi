namespace Kanban.Contracts;

/*
    Interface tipleri daha çok nesne bağımlılıklarını çözümlemek,
    çok biçimliliği karşılamak, plug-in tabanlı kodlama yapmak vb senaryolarda kullanılır.

    Normal iş yapan metotlar veya alanlar içeremezler. 
    Bir interface, onu uygulayan asıl nesneler için mutlaka yazılması gereken üyelerin tanımını içerir.

    Sistemdeki bütün interface türleri büyük I harfi ile başlar ve bu bir isimlendirme standardıdır.

    Interface türünün önemli özelliklerinden birisi, kendisini implemente eden nesne örneklerini taşıyabilmesidir.
    Bu duruma nesne yönelimli dillerde çok biçimlilik (Polymorphyszm) adı da verilir.
*/
public interface ITaskLoader
{
    IEnumerable<Entity.Task> GetTasks(); // Bu interface tipini uygulayanlar GetTasks isimli metodu ezmek(yazmak) zorundadır
}

public interface ITaskSaver
{
    SaveResponse Save(IEnumerable<Entity.Task> tasks);
}
/*
    Kaydetme işlemi gibi operasyonlar geriye daha fazla bilgi dönebilir.
    İşlemin başarılı olup olmadığı, başarılı ise ek bilgi veya bir exception oluştuysa buna ait bilgiler dönülebilir.
*/

public class SaveResponse
{
    public bool IsSuccess { get; set; }
    public Exception Exception { get; set; }
    public string Message { get; set; } = string.Empty;
    public int SavedObjectCount { get; set; }
}

/*
    Yukarıdaki tasarımda okuma ve kaydetme işlevleri farklı arayüzlerde tutulmuştur. Bu, yazma ve okuma işlemlerinin farklı 
    enstrümanlar ile yapılabileceği anlamına da gelir. 
    Ancak design böyle olmak zorunda değildir. Aşağıdaki gibi de tasarlayabiliriz.
*/

public interface ITaskDataContext
{
    IEnumerable<Entity.Task> GetAll();
    string Save(IEnumerable<Entity.Task> tasks);
}