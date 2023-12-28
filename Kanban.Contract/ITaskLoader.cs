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
public interface ITaskLoader
{
    IEnumerable<Entity.Task> GetTasks(); // Bu interface tipini uygulayanlar GetTasks isimli metodu ezmek(yazmak) zorundadır
}