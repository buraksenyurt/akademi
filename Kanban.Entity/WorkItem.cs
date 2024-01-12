namespace Kanban.Entity;

public class WorkItem
{
    public Guid Id { get; } // Readonly
    public string Title { get; set; } = string.Empty;
    public DurationType DurationType { get; set; }
    public byte Duration { get; set; }
    public WorkItemSize WorkItemSize { get; set; }
    private WorkItemState _state;
    public WorkItemState State
    {
        get
        {
            return _state;
        }
        set
        {
            _state = value;
        }
    }
    /*
        Bir WorkItem nesne örneğinin diğerlerinden ayrışması noktasında benzersi Guid değerlerinden yararlanabilir.
        Id dışardına değiştirilemeyen ama bir WorkItem örneği oluşturduğumuzda varsayılan yapıcı tarafından
        otmatik üretilen Guid türünden özelliktir.
    */
    public WorkItem(Guid? id)
    {
        // Guid? tanımındaki ? türün nullable olduğunu gösterir
        // Yani ya bir değeri vardır ya da tanımsız anlamına da gelebilen Null' dür.
        // Bir veri kaynağından okunan WorkItem nesnesinin o kaynaktaki Guid değerini kullanması için bu if bloğu eklendi
        if (id.HasValue)
        {
            Id = id.Value;
        }
        else
        {
            Id = Guid.NewGuid();
        }
        //Console.WriteLine($"WorkItem nesnesi için {Id} üretildi.");
        _state = WorkItemState.Todo;
    }

    public void ChangeState(bool failed = false)
    {
        if ((_state == WorkItemState.Todo || _state == WorkItemState.InProgress) && failed)
        {
            _state = WorkItemState.Undone;
            return;
        }
        switch (_state)
        {
            case WorkItemState.Todo:
                _state = WorkItemState.InProgress;
                break;
            case WorkItemState.InProgress:
            case WorkItemState.Completed:
                _state = WorkItemState.Completed;
                break;
        }
    }

    /*
        ToString metodu Object sınıfında tanımlanmış olan bir fonksiyondur.
        virtual anahtar kelimesi ile tanımlanmıştır.
        Virtual olan metotlar türeyen sınıflarda ezilip tekrardan yazılabilirler.
        Bu şu anlama gelir. Türeyen nesne örneğinin ezilen metodu çağrıldığında değiştirilmiş olan versiyonu işletilir.
        Örneğin Object sınıfındaki ToString metodu virtual tanımlanmıştır, varsayılan bir davranışı vardır eğer bir nesne
        ToString metodunu ezerse(override) artık Object sınıfının ToString metodu değil ezilmiş olan versiyonu çağrılır.
    */
    public override string ToString()
    {
        // Object Nesne üstünde sağ tıklayın -> Go to definition'a basın ve System isim alanındaki Object sınıfının metod
        // bildirimlerini inceleyin.
        return $"{Id}|{Title}|{WorkItemSize}|{Duration}|{DurationType}|{State}";
    }
}