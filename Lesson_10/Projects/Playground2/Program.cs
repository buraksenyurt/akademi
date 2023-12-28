using System.Collections;

namespace Playground2;
/*
    Bu seferki örnekte ise stok parça bilgilerini taşıyan bir sınıfa ait nesne örneği üstünde 
    foreach döngüsünü kullanabilmek için IEnumerable arayüzünün nasıl implemente edildiği işlenmektedir.
*/

class Program
{
    static void Main()
    {
        var parts = GetParts();

        foreach (var part in parts)
        {
            Console.WriteLine(part.ToString());
        }
    }

    static PartCollection GetParts()
    {
        var partCollection = new PartCollection
        {
            new Part
            {
                ID = 1092,
                Name = "Juke Box classic",
                UnitPrice = 999.99M,
                StockLevel = 1
            },
            new Part
            {
                ID = 956,
                Name = "Juke Box Retro",
                UnitPrice = 2999.99M,
                StockLevel = 2
            },
            new Part
            {
                ID = 1480,
                Name = "MFÖ Long Play Collection 1980-2000",
                UnitPrice = 450.99M,
                StockLevel = 6
            },
            new Part
            {
                ID = 13,
                Name = "Kubric Movie Collection",
                UnitPrice = 5500.00M,
                StockLevel = 1
            }
        };
        return partCollection;
    }
}

public class Part
{
    public int ID { get; set; }
    public string Name { get; set; } = "N/A";
    public decimal UnitPrice { get; set; }
    public int CategoryId { get; set; }
    public int StockLevel { get; set; }
    public override string ToString()
    {
        return $"{ID},{Name},{UnitPrice:2M},{StockLevel}";
    }
}

public class PartCollection : IEnumerable<Part>
{
    private readonly List<Part> parts = new();
    public void Add(Part part)
    {
        parts.Add(part);
    }

    public IEnumerator<Part> GetEnumerator()
    {
        foreach (var part in parts.OrderBy(p => p.ID))
        {
            yield return part;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}