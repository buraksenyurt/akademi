namespace TodoApp;

class Program
{
    static void Main(string[] args)
    {        
        WorkItem firstWorkItem = new WorkItem(); // Burada firstWorkItem isimli WorkItem sınıfı(class) türünden bir nesne örneği(object instance) oluşturduk.
        // firstWorkItem.Id = 1; // #1 burası derleme zamanında 'WorkItem.Id' is inaccessible due to its protection level hatasını verir.
        firstWorkItem.Title = "Program içerisindeki sınıfları kütüphaneye(library) taşı";
        firstWorkItem.Duration = 3;
        firstWorkItem.DurationType = DurationType.Day;
        firstWorkItem.WorkItemSize = WorkItemSize.M;
        //firstWorkItem.State = WorkItemState.Todo; // State özelliği(property) read-only olduğundan böyle bir atama yapamayız.

        /*
            Varsayılan olarak, WorkItem sınıfı bir Object türüdür. Bu nedenle firstWorkItem.ToString() ifadesindeki metot çağrısı,
            Object sınıfının ToString() metodunun çağırılması anlamına gelir. Object sınıfındaki ToString() metodu varsayılan(default)
            olarak bir davranış sergiler. Bu davranış uygulandığı veri tipinin adı ile o tipin bulunduğu isim alanının(Namespace) birleşemidir.
            Yani bu örnek için TodoApp.WorkItem şeklinde bir String döndürür. Eğer aksini belirtmezsek ya da bir başka deyişle ToString metodunu
            WorkItem sınıfı için override etmezsek.
        */
        // Console.WriteLine("{0}", firstWorkItem.ToString());
        // var wiInfo = GetWorkItemInfo(firstWorkItem);
        // Console.WriteLine("{0}", wiInfo);

        // Aşağıdaki kullanımda WorkItem sınıfının fonksiyonundan yararlanılmıştır.
        // Üstteki kullanım şekli yerine bu tercih edilebilir.
        Console.WriteLine("{0}", firstWorkItem.GetInfo());

        // Bir sınıf nesnesini aşağıdaki ifade ile de oluşturabiliriz
        var secondWorkItem = new WorkItem
        {
            Title = "DoAccounting fonksiyonundaki Cognitive Complexity değerini 15in atlına indir",
            WorkItemSize = WorkItemSize.L,
            Duration = 7,
            DurationType = DurationType.Day
        };
        Console.WriteLine("{0}", secondWorkItem.GetInfo());
        // Soru: State değiştirirken, var olan state ne ise bir sonrakine otomatik olarak geçse. Bunu nasıl yapabiliriz?
        //secondWorkItem.ChangeState(WorkItemState.InProgress);
        secondWorkItem.ChangeState();
        Console.WriteLine("{0}", secondWorkItem.GetInfo());
        secondWorkItem.ChangeState();
        Console.WriteLine("{0}", secondWorkItem.GetInfo());

        var thirdWorkItem = new WorkItem
        {
            Title = "Projedeki switch bloklarını if bloğuna çevir.",
            WorkItemSize = WorkItemSize.M,
            Duration = 6,
            DurationType = DurationType.Hour,
        };
        Console.WriteLine("{0}", thirdWorkItem.GetInfo());
        thirdWorkItem.ChangeState();
        Console.WriteLine("{0}", thirdWorkItem.GetInfo());
        thirdWorkItem.ChangeState(true);
        Console.WriteLine("{0}", thirdWorkItem.GetInfo());

        /*
            Program bu noktaya kadar birden fazla WorkItem nesnesi örnekledi. 
            Bunlar üzerinde toplu işlemler yaptırmak istersek bir veri serisinde tutmak iyi olabilir.
            Diziler(Arrays) en bilinen veri saklama yöntemlerindendir.
            Aşağıda 3 elemanlı bir WorkItem dizisi tanımandı.
            Diziler aynı türden elemanları barındırır, boyutları sabittir ve başlangıçta belirtilir.
        */
        WorkItem[] workItems = new WorkItem[3];
        workItems[0] = firstWorkItem;
        workItems[1] = secondWorkItem;
        workItems[2] = thirdWorkItem;
        // workItems[3] = new WorkItem(); // Dizi 3 eleman alacak şekilde tanımlandığından bu satırda System.IndexOutOfRangeException: Index was outside the bounds of the array. hatası alınır.

        // integer i değeri 0 dan başlamak usulüyle, workItems dizisindeki eleman sayısı kadar hareket edecek bir döngü başlat.
        for (int i = 0; i < workItems.Length; i++)
        {
            // [i] operatörü ile workItems dizinin elemanına erişilebilir
            Console.WriteLine("[{0}]-{1}", i, workItems[i].GetInfo());
        }

        // workItems değişkeni ile belirtilen seri içindeki her bir elemanı wi değişkeni olarak ele al.
        foreach (var wi in workItems)
        {
            Console.WriteLine("{0}", wi.GetInfo());
        }
    }

    /*
        GetWorkItemInfo isimli metodumuz, WorkItem türünden parametre alır ve geriye string türünden bir değer döndürür.
        Bu metodu yani bir WorkItem'ın içeriği ile ilgili string veri döndüren fonksiyonu WorkItem sınıfı içerisinde de doğrudan
        tanımlayabiliriz.
    */
    public static string GetWorkItemInfo(WorkItem wi)
    {
        // var info = $"{wi.Title}({wi.Duration}-{wi.DurationType},{wi.State})";
        // return info;
        return $"{wi.Title}({wi.Duration}-{wi.DurationType},{wi.State})";
    }
}

/*
    public bir erişim belirleyicisidir(Access Modifier). Uygulandığı tipin herkes tarafından kullanılabileceğini belirtir.
    public dışında, private, internal, protected, protected interal gibi erişim belirleyicileri de söz konusudur.
*/
class WorkItem
{
    int Id { get; set; } // bu private bir alan olduğundan #1 daki kod işletilemez.
    public string Title { get; set; } = string.Empty;
    public DurationType DurationType { get; set; }
    public byte Duration { get; set; }
    public WorkItemSize WorkItemSize { get; set; } // Auto Property
    /*
        WorkItemState özelliği esasında _state isimli private alanı kullanır. private olduğu için,
        _state değişkenine sadece WorkItem sınıfı içindeki fonksiyonlar erişebilir.
        Dolayısıyla bir WorkItem nesne örneğinin state'ini değiştirmek istediğimizde,
        dışarıya açık bir metod üstünden ilerleyebiliriz. ChangeState metodu _state isimli alanın
        değerini değiştirir. Bu sayede nesne örneği üstünden State özelliğine gittiğimizde,
        aslında _state değişkeninin değerini de alabiliriz.
    */
    private WorkItemState _state;
    public WorkItemState State
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
        return $"{Title}[{WorkItemSize}] ({Duration}-{DurationType},{State})";
    }
    // ChangeState metodu ile bir WorkItem'ın güncel durumunun değiştirilmesine imkan sağlanır.
    // Normal şartlarda State özelliği, _state isimli alanı(field) kullanmaktadır ve dışarıdan sadece okunabilir bir özelliktir
    // public void ChangeState(WorkItemState newState)
    // {
    //     _state = newState;
    // }

    /*
        ChangeState, WorkItem nesne örneğinin güncel durumuna bakarak bir değişiklik yapar.
        failed optional parametre'dir. Yani değerini vermezsek false olarak kabul edilir.
        true olarak atarsak o zaman failed olduğu anlamına gelir ve durum Undone'a çekilir. Ama güncel state'i Todo veya Inprogress ise
    */
    public void ChangeState(bool failed = false)
    {
        // State Todo veya InProgress'te iken başarılamadı ise Completed yerine Undone duruma geçmeli
        if ((_state == WorkItemState.Todo || _state == WorkItemState.InProgress) && failed)
        {
            _state = WorkItemState.Undone;
            return; // aşağıdaki kod satırlarını işletmeye gerek olmadığından metottan doğrudan çıkılır.
        }
        /*
            switch bloğu ile _state değerinin hangi durumda olduğuna göre bir işlem yapılmakta.
        */
        switch (_state)
        {
            case WorkItemState.Todo: // güncel state Todo ise
                _state = WorkItemState.InProgress;
                break; // switch bloğundan çıkılmasını sağlar
            case WorkItemState.InProgress: // güncel state InProgress veya Completed ise
            case WorkItemState.Completed:
                _state = WorkItemState.Completed;
                break;
        }
    }
}

enum DurationType
{
    Hour,
    Day,
    Week,
    Month,
    Year
}
enum WorkItemSize
{
    S,
    M,
    L,
    XL
}
enum WorkItemState
{
    Todo,
    InProgress,
    Completed,
    Undone
}
