using System.Text;
using Kanban.Entity;
using Kanban.Runtime;

namespace Kanban.Data;

public class TaskManager
{
    #region Events

    /*
        Olaylar konusuna dair örnek kodlar için eklenmiştir. Örneğin sisteme yeni bir oyun eklendiğinde,
        NewTaskAdded isimli olay tetiklenir. Bu olaya abone olan taraflar(genellikle bu nesneyi kullanan istemcidir) 
        olayla ilgili farklı işlemler yapabilir. Abonelerin ihtiyacı olabilecek ekstra bilgiler bir nesne üzerinden taşınabilir.
        Bu senaryoda olayın adı NewTaskAdded, bu olayla ilgili EventHandler tipi NewTaskAddedEventHandler, olayla ilgili
        detay bilgi taşıyan sınıf ise NewTaskAddedEventHandlerArgs türüdür.
    */

    public event NewTaskAddedEventHandler NewTaskAdded;

    #endregion
    /*
        Şimdilik belli sayıda Task nesne örneğini tutacak şekilde bir array tanımladık
        _tasks, Entity kütüphanesindeki Task türünden bir dizidir.
        private olarak tanımlanmıştır, dolayısıyla sadece TaskManager sınıfının kendi metotları tarafından kullanılabilir.
    */
    //private Entity.Task[] _tasks;
    // Yeni modelimizde Task nesnelerini generic List tipi ile tutmaktayız
    private readonly List<Entity.Task> _tasks;

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
        //Load("Board");
    }

    // /*
    //     Load ve alttaki save metotları Kanban.Data için sıkı bağlı bir nesne ilişkisine sebebiyet verir.
    //     Yani farklı bir formatta okuma ve kaydetme işlemi için buradaki metot içeriklerini değiştirmek zorunda kalırız.
    //     Oysa ki bu tip nesne bağımlılıkları kütüphane içerisine dışarıdan verilebilir. Böyle Loosely Coupled Dependency'ler oluşur.
    // */
    // private void Load(string fileName)
    // {
    //     try
    //     {
    //         var filePath = Path.Combine(Environment.CurrentDirectory, $"{fileName}.csv");
    //         // filePath ile belirtilen dosya içeriğini satır olarak okur
    //         var lines = File.ReadAllLines(filePath);
    //         // her bir satırı el al
    //         foreach (var line in lines)
    //         {
    //             // Her bir satırı | işaretine göre ayır
    //             var columns = line.Split('|');
    //             // Her bir satır içinde bir Task nesnesi örneklenir
    //             Entity.Task newTask = new(Guid.Parse(columns[0]))
    //             {
    //                 Title = columns[1],
    //                 TaskSize = (TaskSize)Enum.Parse(typeof(TaskSize), columns[2]), // Parse object döndüğünde açık bir şekilde (TaskSize) ile dönüştürme yapılması gerekir.
    //                 Duration = Convert.ToByte(columns[3]),
    //                 DurationType = Enum.Parse<DurationType>(columns[4]),
    //                 State = Enum.Parse<TaskState>(columns[5])
    //             };
    //             // Oluşturulan yeni Task nesnesi koleksiyona eklenir
    //             _tasks.Add(newTask);
    //         }
    //     }
    //     catch (Exception excp)
    //     {

    //     }
    // }

    // İçerideki task deposuna yeni bir eleman eklemek için kullanılan fonksiyon
    // Parametre olarak Task nesnesi alır, ekleme işlemini yapar ve geriye eklenen task için üretilen benzersiz id değerini döndürür.
    public Guid Add(Entity.Task newTask)
    {
        _tasks.Add(newTask);
        var taskId = newTask.Id;
        NewTaskAdded?.Invoke(newTask, new NewTaskAddedEventArgs { TaskId = taskId });
        return taskId;
    }
    // Belli bir Id değerine sahip Task nesnesinin bulunması için kullanılır.
    public Entity.Task? GetTask(Guid taskId)
    {
        return _tasks.SingleOrDefault(t => t.Id == taskId);
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

    /*
        Save metodu dosyaya yazma işini üstlenen bir fonksiyon.
        İşlemin başarılı olup olmadığı true veya false olarak dönülebileceği gibi
        kendi tasarladığımız bir mesajı da (yani bir sınıfa ait nesne örneğini) dönebiliriz.
    */
    //TODO @buraksenyurt TaskManager sınıfındaki metotların giriş ve çıkış nesneleri için sınıf tasarlayalım.
    public bool Save(string fileName)
    {
        try
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, $"{fileName}.csv");
            // Satır bazındaki veri içeriğin kolayca hazırlamak için StringBuilder kullandık
            StringBuilder stringBuilder = new();
            // Her bir Task nesne örneğini dolaşacağımız bir döngü başlattık
            foreach (var task in _tasks)
            {
                // Herbir Task nesne örneği için arada pipe işareti olan bir metin katarı oluşturduk
                var line = task.ToString(); // ToString metodunu override ettiğimiz için aralara | konulan bir içeriği kolayca elde edebiliriz.
                //var line = $"{task.Id}|{task.Title}|{task.TaskSize}|{task.Duration}|{task.DurationType}|{task.State}";
                // Oluşan line değeri stringBuilder'a satır olarak eklenir
                stringBuilder.AppendLine(line);
            }
            File.WriteAllText(filePath, stringBuilder.ToString());
            return true;
        }
        catch (Exception excp)
        {
            // QUESTION Burada alınan exception ne yapılmalıdır?
            return false;
        }

        // // İlgili metodun henüz yazılmadığına dair çalışma zamanına bir istisna fırlatır
        // // throw keyword'u ile bir Exception'ı bilinçli olarak çalışma zamanına fırlatabiliriz.
        // throw new NotImplementedException();
    }
}
