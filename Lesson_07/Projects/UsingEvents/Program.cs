namespace UsingEvents;

class Program
{
    static void Main(string[] args)
    {
        var ambar = new Deppo
        {
            Id = 1,
            Name = "Elektronik Hırdavatçı",
            ProductCount = 100
        };
        // Eğer ambar isimli ürünün stok değeri 25'in altına inerse 
        // buradaki olay metodu çalıştırılır.
        // sender genelde olayın sahibi olan nesneyi ifade etmek içindir.
        ambar.StockLevelLow += (sender, eventArgs) =>
        {
            Console.WriteLine($"Stok kritik seviyede.\nEski stok seviyesi {eventArgs.OldLevel}. Yeni stok seviyesi ise {eventArgs.NewLevel}");
        };

        ambar.Sold(40);
        ambar.Sold(40);
    }
}

public class Deppo
{
    public int Id { get; set; }
    public string Name { get; set; } = "Anonymous";
    public int ProductCount { get; set; }
    public void Sold(int quantity)
    {
        ProductCount -= quantity;
        // ProductCount değeri 25'in altında ise
        if (ProductCount < 25)
        {
            // StockLevelLow event'ini tetikle
            // Bir event bir delegate tipiyle ilişkilendirildiğinden
            // Buradaki çağrı StockLevelLow temsilcisine yüklenen metodu işletecektir
            // Parametre olarak olayla ilgili ektstra bilgi taşımak için 
            // StockLevelLowEventArgs nesne örneğinden yararlanılır.
            StockLevelLow(this, new StockLevelLowEventArgs
            {
                OldLevel = quantity,
                NewLevel = ProductCount
            });
        }
    }
    // StockLevelLowEventHandler isimli temsilcinin işaret ettiği
    // metodu çağırabilen event değişkeni
    //public event StockLevelLowEventHandler StockLevelLow;

    // Genelde iki parametre alıp ilki olayın sahibi olan nesneyi işaret eden object türünden bir parametre olup
    // ikincisi generic olarak verilebilen olaylar söz konusu ise .Net ile birlikte gelen
    // EventHandler<T> temsilcisi de kullanılabilir. Yani StockLevelLowEventHandler yerine
    // EventHandler<StockLevelEventArgs> temsilcisi de kullanılabilir.
    public event EventHandler<StockLevelLowEventArgs> StockLevelLow;
}

// StockLevelLowEventHandler isimli temsilci, object ve StockLevelLowEventArgs türünden
// iki parametre alıp geriye bir şey döndürmeyen(void) metotları işaret eder
public delegate void StockLevelLowEventHandler(object source, StockLevelLowEventArgs eventArgs);

// Olay metotlarına girmesi gereken ek parametreler varsa bunlar için ayrı bir nesne modeli tasarlanabilir
public class StockLevelLowEventArgs
{
    public int OldLevel { get; set; }
    public int NewLevel { get; set; }
}
