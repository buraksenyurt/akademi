using Kanban.Contract;
using Kanban.Entity;
using Kanban.Runtime;

namespace Kanban.Data;

public class WorkItemManager
{
    #region Events

    /*
        Olaylar konusuna dair örnek kodlar için eklenmiştir. Örneğin sisteme yeni bir oyun eklendiğinde,
        newWorkItemAdded isimli olay tetiklenir. Bu olaya abone olan taraflar(genellikle bu nesneyi kullanan istemcidir) 
        olayla ilgili farklı işlemler yapabilir. Abonelerin ihtiyacı olabilecek ekstra bilgiler bir nesne üzerinden taşınabilir.
        Bu senaryoda olayın adı newWorkItemAdded, bu olayla ilgili EventHandler tipi newWorkItemAddedEventHandler, olayla ilgili
        detay bilgi taşıyan sınıf ise newWorkItemAddedEventHandlerArgs türüdür.
    */

    public event WorkItemAddedEventHandler newWorkItemAdded;

    #endregion
    /*
        Şimdilik belli sayıda WorkItem nesne örneğini tutacak şekilde bir array tanımladık
        _workItems, Entity kütüphanesindeki WorkItem türünden bir dizidir.
        private olarak tanımlanmıştır, dolayısıyla sadece WorkItemManager sınıfının kendi metotları tarafından kullanılabilir.
    */
    //private Entity.WorkItem[] _workItems;
    // Yeni modelimizde WorkItem nesnelerini generic List tipi ile tutmaktayız
    private readonly List<WorkItem> _workItems;

    /*
        Aşağıdaki metot bir yapıcı metoddur(constructor)
        Yapıcı metotlar sınıf adı ile aynı isme sahip olan ve geriye hiçbir şey döndürmeyen(ama void değil) metotlardır.
        İşlevi şudur; bu metot tanımlandığı sınıfa ait bir nesne örneği oluşturulurken çalışır.
        Yani, program WorkItemManager sınıfını kullanmak isterseniz önce onu new operatörü ile oluşturmanız gerekir.
        Bunu yaptığımız zaman aşağıdaki versiyonu kullanmamız gerekir.
        Dolayısıyla WorkItemManager sınıfından bir nesne örneklerken, içereceği _workItems dizisinin de kaç elemandan oluşacağını
        belirleyebilirsiniz.

    */
    // public WorkItemManager(int workItemCount)
    // {
    //     _workItems = new WorkItem[workItemCount];
    // }
    // WorkItemManager sınıfının varsayılan yapıcı metodu(Default Constructor) çalıştığında
    // _workItems isimli değişkene ait generic List koleksiyonu da örneklenir.
    public WorkItemManager(IWorkItemLoader loader)
    {
        /*
            Yapıcı metodumuz IWorkItemLoader ile bu arayüzü implemente eden herhangibir nesneyi kullanabilir.
            Bu şekilde bir nesne bağımlılığını dışarıdan içeriye enjekte edebiliriz. Depedency Injection.
            SOLID yazılım prensiplerinin Dependency Inversion ilkesini sağlamak için kullanılan tekniktir.
        */
        var response = loader.GetWorkItems();
        if (response != null && response.WorkItems != null)
        {
            _workItems = response.IsSuccess ? response.WorkItems.ToList() : new List<WorkItem>();
        }
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
    //             // Her bir satır içinde bir WorkItem nesnesi örneklenir
    //             WorkItem newWorkItem = new(Guid.Parse(columns[0]))
    //             {
    //                 Title = columns[1],
    //                 WorkItemSize = (WorkItemSize)Enum.Parse(typeof(WorkItemSize), columns[2]), // Parse object döndüğünde açık bir şekilde (WorkItemSize) ile dönüştürme yapılması gerekir.
    //                 Duration = Convert.ToByte(columns[3]),
    //                 DurationType = Enum.Parse<DurationType>(columns[4]),
    //                 State = Enum.Parse<WorkItemState>(columns[5])
    //             };
    //             // Oluşturulan yeni WorkItem nesnesi koleksiyona eklenir
    //             _workItems.Add(newWorkItem);
    //         }
    //     }
    //     catch (Exception excp)
    //     {

    //     }
    // }

    // İçerideki WorkItem deposuna yeni bir eleman eklemek için kullanılan fonksiyon
    // Parametre olarak WorkItem nesnesi alır, ekleme işlemini yapar ve geriye eklenen WorkItem için üretilen benzersiz id değerini döndürür.
    public Guid Add(WorkItem newWorkItem)
    {
        _workItems.Add(newWorkItem);
        var wiId = newWorkItem.Id;
        newWorkItemAdded?.Invoke(newWorkItem, new WorkItemAddedEventArgs { WorkItemId = wiId });
        return wiId;
    }
    // Belli bir Id değerine sahip WorkItem nesnesinin bulunması için kullanılır.
    public WorkItem? GetWorkItem(Guid workItemId)
    {
        return _workItems.SingleOrDefault(t => t.Id == workItemId);
        // foreach (var wi in _workItems)
        // {
        //     if (wi.Id.Equals(workItemId))
        //     {
        //         return wi;
        //     }
        // }
        // return null;
    }

    // Bu metot içerideki _workItems dizisinin belirtilen durumdaki elemanlarının sayısını döndürür.
    // Böylece kaç tane işlemde olan WorkItem var, ya da kaç tane tamamlanmış WorkItem var gibi soruların cevaplarını alabiliriz.
    public int GetWorkItemCount(WorkItemState workItemState)
    {
        return _workItems.Where(t => t.State == workItemState).Count(); // Örnek bir LINQ sorgusu. Aşağıdaki kod satırları yerine kullanılabilir        
        // int count = 0;
        // foreach (var wi in _workItems)
        // {
        //     if (wi.State == workItemState)
        //     {
        //         count++;
        //     }
        // }
        // return count;
    }

    // Aşağıdaki metot belli bir state altındaki WorkItem nesnelerinin dizisini döndürür
    public List<WorkItem> GetWorkItems(WorkItemState workItemState)
    {
        return _workItems.Where(t => t.State == workItemState).ToList();
        // var resultSet = new List<WorkItem>();
        // foreach (var wi in _workItems)
        // {
        //     if (wi.State == workItemState)
        //     {
        //         resultSet.Add(wi);
        //     }
        // }
        // return resultSet;
    }

    /*
        Bu sefer nesne bağımlılığı metot üzerinden enjekte edilmektedir.(Dependency Injection)
    */
    public SaveResponse Save(IWorkItemSaver saver)
    {
        return saver.Save(_workItems);
    }

    // /*
    //     Save metodu dosyaya yazma işini üstlenen bir fonksiyon.
    //     İşlemin başarılı olup olmadığı true veya false olarak dönülebileceği gibi
    //     kendi tasarladığımız bir mesajı da (yani bir sınıfa ait nesne örneğini) dönebiliriz.
    // */
    // public bool Save(string fileName)
    // {
    //     try
    //     {
    //         var filePath = Path.Combine(Environment.CurrentDirectory, $"{fileName}.csv");
    //         // Satır bazındaki veri içeriğin kolayca hazırlamak için StringBuilder kullandık
    //         StringBuilder stringBuilder = new();
    //         // Her bir WorkItem nesne örneğini dolaşacağımız bir döngü başlattık
    //         foreach (var wi in _workItems)
    //         {
    //             // Herbir WorkItem nesne örneği için arada pipe işareti olan bir metin katarı oluşturduk
    //             var line = wi.ToString(); // ToString metodunu override ettiğimiz için aralara | konulan bir içeriği kolayca elde edebiliriz.
    //             //var line = $"{wi.Id}|{wi.Title}|{wi.WorkItemSize}|{wi.Duration}|{wi.DurationType}|{wi.State}";
    //             // Oluşan line değeri stringBuilder'a satır olarak eklenir
    //             stringBuilder.AppendLine(line);
    //         }
    //         File.WriteAllText(filePath, stringBuilder.ToString());
    //         return true;
    //     }
    //     catch (Exception excp)
    //     {
    //         // QUESTION Burada alınan exception ne yapılmalıdır?
    //         return false;
    //     }

    //     // // İlgili metodun henüz yazılmadığına dair çalışma zamanına bir istisna fırlatır
    //     // // throw keyword'u ile bir Exception'ı bilinçli olarak çalışma zamanına fırlatabiliriz.
    //     // throw new NotImplementedException();
    // }
}
