namespace TodoApp;

class Program
{
    static void Main(string[] args)
    {        
        Task firstTask = new Task(); // Burada firstTask isimli Task sınıfı(class) türünden bir nesne örneği(object instance) oluşturduk.
        // firstTask.Id = 1; // #1 burası derleme zamanında 'Task.Id' is inaccessible due to its protection level hatasını verir.
        firstTask.Title = "Program içerisindeki sınıfları kütüphaneye(library) taşı";
        firstTask.Duration = 3;
        firstTask.DurationType = DurationType.Day;
        firstTask.TaskSize = TaskSize.M;
        //firstTask.State = TaskState.Todo; // State özelliği(property) read-only olduğundan böyle bir atama yapamayız.

        /*
            Varsayılan olarak, Task sınıfı bir Object türüdür. Bu nedenle firstTask.ToString() ifadesindeki metot çağrısı,
            Object sınıfının ToString() metodunun çağırılması anlamına gelir. Object sınıfındaki ToString() metodu varsayılan(default)
            olarak bir davranış sergiler. Bu davranış uygulandığı veri tipinin adı ile o tipin bulunduğu isim alanının(Namespace) birleşemidir.
            Yani bu örnek için TodoApp.Task şeklinde bir String döndürür. Eğer aksini belirtmezsek ya da bir başka deyişle ToString metodunu
            Task sınıfı için override etmezsek.
        */
        // Console.WriteLine("{0}", firstTask.ToString());
        // var taskInfo = GetTaskInfo(firstTask);
        // Console.WriteLine("{0}", taskInfo);

        // Aşağıdaki kullanımda Task sınıfının fonksiyonundan yararlanılmıştır.
        // Üstteki kullanım şekli yerine bu tercih edilebilir.
        Console.WriteLine("{0}", firstTask.GetInfo());

        // Bir sınıf nesnesini aşağıdaki ifade ile de oluşturabiliriz
        var secondTask = new Task
        {
            Title = "DoAccounting fonksiyonundaki Cognitive Complexity değerini 15in atlına indir",
            TaskSize = TaskSize.L,
            Duration = 7,
            DurationType = DurationType.Day
        };
        Console.WriteLine("{0}", secondTask.GetInfo());
        // Soru: State değiştirirken, var olan state ne ise bir sonrakine otomatik olarak geçse. Bunu nasıl yapabiliriz?
        //secondTask.ChangeState(TaskState.InProgress);
        secondTask.ChangeState();
        Console.WriteLine("{0}", secondTask.GetInfo());
        secondTask.ChangeState();
        Console.WriteLine("{0}", secondTask.GetInfo());

        var thirdTask = new Task
        {
            Title = "Projedeki switch bloklarını if bloğuna çevir.",
            TaskSize = TaskSize.M,
            Duration = 6,
            DurationType = DurationType.Hour,
        };
        Console.WriteLine("{0}", thirdTask.GetInfo());
        thirdTask.ChangeState();
        Console.WriteLine("{0}", thirdTask.GetInfo());
        thirdTask.ChangeState(true);
        Console.WriteLine("{0}", thirdTask.GetInfo());

        /*
            Program bu noktaya kadar birden fazla Task nesnesi örnekledi. 
            Bunlar üzerinde toplu işlemler yaptırmak istersek bir veri serisinde tutmak iyi olabilir.
            Diziler(Arrays) en bilinen veri saklama yöntemlerindendir.
            Aşağıda 3 elemanlı bir Task dizisi tanımandı.
            Diziler aynı türden elemanları barındırır, boyutları sabittir ve başlangıçta belirtilir.
        */
        Task[] tasks = new Task[3];
        tasks[0] = firstTask;
        tasks[1] = secondTask;
        tasks[2] = thirdTask;
        // tasks[3] = new Task(); // Dizi 3 eleman alacak şekilde tanımlandığından bu satırda System.IndexOutOfRangeException: Index was outside the bounds of the array. hatası alınır.

        // integer i değeri 0 dan başlamak usulüyle, tasks dizisindeki eleman sayısı kadar hareket edecek bir döngü başlat.
        for (int i = 0; i < tasks.Length; i++)
        {
            // [i] operatörü ile tasks dizinin elemanına erişilebilir
            Console.WriteLine("[{0}]-{1}", i, tasks[i].GetInfo());
        }

        // tasks değişkeni ile belirtilen seri içindeki her bir elemanı task değişkeni olarak ele al.
        foreach (var task in tasks)
        {
            Console.WriteLine("{0}", task.GetInfo());
        }
    }

    /*
        GetTaskInfo isimli metodumuz, Task türünden parametre alır ve geriye string türünden bir değer döndürür.
        Bu metodu yani bir task'ın içeriği ile ilgili string veri döndüren fonksiyonu Task sınıfı içerisinde de doğrudan
        tanımlayabiliriz.
    */
    public static string GetTaskInfo(Task task)
    {
        // var info = $"{task.Title}({task.Duration}-{task.DurationType},{task.State})";
        // return info;
        return $"{task.Title}({task.Duration}-{task.DurationType},{task.State})";
    }
}

/*
    public bir erişim belirleyicisidir(Access Modifier). Uygulandığı tipin herkes tarafından kullanılabileceğini belirtir.
    public dışında, private, internal, protected, protected interal gibi erişim belirleyicileri de söz konusudur.
*/
class Task
{
    int Id { get; set; } // bu private bir alan olduğundan #1 daki kod işletilemez.
    public string Title { get; set; } = string.Empty;
    public DurationType DurationType { get; set; }
    public byte Duration { get; set; }
    public TaskSize TaskSize { get; set; } // Auto Property
    /*
        TaskState özelliği esasında _state isimli private alanı kullanır. private olduğu için,
        _state değişkenine sadece Task sınıfı içindeki fonksiyonlar erişebilir.
        Dolayısıyla bir Task nesne örneğinin state'ini değiştirmek istediğimizde,
        dışarıya açık bir metod üstünden ilerleyebiliriz. ChangeState metodu _state isimli alanın
        değerini değiştirir. Bu sayede nesne örneği üstünden State özelliğine gittiğimizde,
        aslında _state değişkeninin değerini de alabiliriz.
    */
    private TaskState _state;
    public TaskState State
    {
        get
        {
            return _state;
        }
        // set
        // {
        //     _state = value; // value bir keyword'tür ve dışarıdan State'e atılan değeri ifade eder.
        // }
    }
    // read-only yani sadece okunabilir bir özellik
    // GetInfo, bir object instance metodudur. Yani bu sınıfın bir metodudur.
    // Parametre almıyor ve geriye string türünden değer döndürmektedir.
    public string GetInfo()
    {
        return $"{Title}[{TaskSize}] ({Duration}-{DurationType},{State})";
    }
    // ChangeState metodu ile bir Task'ın güncel durumunun değiştirilmesine imkan sağlanır.
    // Normal şartlarda State özelliği, _state isimli alanı(field) kullanmaktadır ve dışarıdan sadece okunabilir bir özelliktir
    // public void ChangeState(TaskState newState)
    // {
    //     _state = newState;
    // }

    /*
        ChangeState, Task nesne örneğinin güncel durumuna bakarak bir değişiklik yapar.
        failed optional parametre'dir. Yani değerini vermezsek false olarak kabul edilir.
        true olarak atarsak o zaman failed olduğu anlamına gelir ve durum Undone'a çekilir. Ama güncel state'i Todo veya Inprogress ise
    */
    public void ChangeState(bool failed = false)
    {
        // State Todo veya InProgress'te iken başarılamadı ise Completed yerine Undone duruma geçmeli
        if ((_state == TaskState.Todo || _state == TaskState.InProgress) && failed)
        {
            _state = TaskState.Undone;
            return; // aşağıdaki kod satırlarını işletmeye gerek olmadığından metottan doğrudan çıkılır.
        }
        /*
            switch bloğu ile _state değerinin hangi durumda olduğuna göre bir işlem yapılmakta.
        */
        switch (_state)
        {
            case TaskState.Todo: // güncel state Todo ise
                _state = TaskState.InProgress;
                break; // switch bloğundan çıkılmasını sağlar
            case TaskState.InProgress: // güncel state InProgress veya Completed ise
            case TaskState.Completed:
                _state = TaskState.Completed;
                break;
        }
    }
}

enum DurationType
{
    Hour,
    Day,
    Month,
    Year
}
enum TaskSize
{
    S,
    M,
    L,
    XL
}
enum TaskState
{
    Todo,
    InProgress,
    Completed,
    Undone
}
