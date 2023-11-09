using Entity;

namespace Kanban.Data;

public class TaskManager
{
    /*
        Şimdilik belli sayıda Task nesne örneğini tutacak şekilde bir array tanımladık
        _tasks, Entity kütüphanesindeki Task türünden bir dizidir.
        private olarak tanımlanmıştır, dolayısıyla sadece TaskManager sınıfının kendi metotları tarafından kullanılabilir.
    */
    private Entity.Task[] _tasks;

    /*
        Aşağıdaki metot bir yapıcı metoddur(constructor)
        Yapıcı metotlar sınıf adı ile aynı isme sahip olan ve geriye hiçbir şey döndürmeyen(ama void değil) metotlardır.
        İşlevi şudur; bu metot tanımlandığı sınıfa ait bir nesne örneği oluşturulurken çalışır.
        Yani, program TaskManager sınıfını kullanmak isterseniz önce onu new operatörü ile oluşturmanız gerekir.
        Bunu yaptığımız zaman aşağıdaki versiyonu kullanmamız gerekir.
        Dolayısıyla TaskManager sınıfından bir nesne örneklerken, içereceği _tasks dizisinin de kaç elemandan oluşacağını
        belirleyebilirsiniz.

    */
    public TaskManager(int taskCount)
    {
        _tasks = new Entity.Task[taskCount];
    }

    // İçerideki task disizine yeni bir eleman eklemek için kullanılan fonksiyon
    // Parametre olarak Task nesnesi alır, ekleme işlemini yapar ve geriye eklenen task için üretilen benzersiz id değerini döndürür.
    public int Add(Entity.Task newTask)
    {
        return 0;
    }
    // Belli bir Id değerine sahip Task nesnesinin bulunması için kullanılır.
    public Entity.Task GetTask(int taskId){
        return null;
    }

    // Bu metot içerideki _tasks dizisinin belirtilen durumdaki elemanlarının sayısını döndürür
    // Böylece kaç tane işlemde olan task var, ya da kaç tane tamamlanmış task var gibi soruların cevaplarını alabiliriz
    public int GetTaskCount(TaskState taskState)
    {
        return _tasks.Length;
    }

    // Aşağıdaki metot belli bir state altındaki Task nesnelerinin dizisini döndürür
    public Entity.Task[] GetTasks(TaskState taskState)
    {
        return Array.Empty<Entity.Task>();
    }
}
