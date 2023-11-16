﻿using Kanban.Entity;

namespace Kanban.Data;

public class TaskManager
{
    /*
        Şimdilik belli sayıda Task nesne örneğini tutacak şekilde bir array tanımladık
        _tasks, Entity kütüphanesindeki Task türünden bir dizidir.
        private olarak tanımlanmıştır, dolayısıyla sadece TaskManager sınıfının kendi metotları tarafından kullanılabilir.
    */
    //private Entity.Task[] _tasks;
    // Yeni modelimizde Task nesnelerini generic List tipi ile tutmaktayız
    private List<Entity.Task> _tasks;

    /*
        Aşağıdaki metot bir yapıcı metoddur(constructor)
        Yapıcı metotlar sınıf adı ile aynı isme sahip olan ve geriye hiçbir şey döndürmeyen(ama void değil) metotlardır.
        İşlevi şudur; bu metot tanımlandığı sınıfa ait bir nesne örneği oluşturulurken çalışır.
        Yani, program TaskManager sınıfını kullanmak isterseniz önce onu new operatörü ile oluşturmanız gerekir.
        Bunu yaptığımız zaman aşağıdaki versiyonu kullanmamız gerekir.
        Dolayısıyla TaskManager sınıfından bir nesne örneklerken, içereceği _tasks dizisinin de kaç elemandan oluşacağını
        belirleyebilirsiniz.

    */
    // public TaskManager(int taskCount)
    // {
    //     _tasks = new Entity.Task[taskCount];
    // }
    // TaskManager sınıfının varsayılan yapıcı metodu(Default Constructor) çalıştığında
    // _tasks isimli değişkene ait generic List koleksiyonu da örneklenir.
    public TaskManager()
    {
        _tasks = new List<Entity.Task>();
    }

    // İçerideki task deposuna yeni bir eleman eklemek için kullanılan fonksiyon
    // Parametre olarak Task nesnesi alır, ekleme işlemini yapar ve geriye eklenen task için üretilen benzersiz id değerini döndürür.
    public Guid Add(Entity.Task newTask)
    {
        _tasks.Add(newTask);
        return newTask.Id;
    }
    // Belli bir Id değerine sahip Task nesnesinin bulunması için kullanılır.
    public Entity.Task? GetTask(Guid taskId)
    {
        return _tasks.SingleOrDefault(t=>t.Id==taskId);
        // foreach (var task in _tasks)
        // {
        //     if (task.Id.Equals(taskId))
        //     {
        //         return task;
        //     }
        // }
        // return null;
    }

    // Bu metot içerideki _tasks dizisinin belirtilen durumdaki elemanlarının sayısını döndürür.
    // Böylece kaç tane işlemde olan task var, ya da kaç tane tamamlanmış task var gibi soruların cevaplarını alabiliriz.
    public int GetTaskCount(TaskState taskState)
    {
        return _tasks.Where(t => t.State == taskState).Count(); // Örnek bir LINQ sorgusu. Aşağıdaki kod satırları yerine kullanılabilir        
        // int count = 0;
        // foreach (var task in _tasks)
        // {
        //     if (task.State == taskState)
        //     {
        //         count++;
        //     }
        // }
        // return count;
    }

    // Aşağıdaki metot belli bir state altındaki Task nesnelerinin dizisini döndürür
    public List<Entity.Task> GetTasks(TaskState taskState)
    {
        return _tasks.Where(t => t.State == taskState).ToList();
        // var resultSet = new List<Entity.Task>();
        // foreach (var task in _tasks)
        // {
        //     if (task.State == taskState)
        //     {
        //         resultSet.Add(task);
        //     }
        // }
        // return resultSet;
    }
}
