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
        Console.WriteLine("{0}",firstTask.GetInfo());
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
    public string Title { get; set; }
    public DurationType DurationType { get; set; }
    public byte Duration { get; set; }
    public TaskSize TaskSize { get; set; }
    public TaskState State { get; } // read-only yani sadece okunabilir bir özellik
    // GetInfo, bir object instance metodudur. Yani bu sınıfın bir metodudur.
    // Parametre almıyor ve geriye string türünden değer döndürmektedir.
    public string GetInfo()
    {
        return $"{task.Title}({task.Duration}-{task.DurationType},{task.State})";
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
