namespace Playground;

/*
    Interface türünün kullanım alanlarından birisi de .Net içerisindeki bazı tiplere yeni davranış şekilleri öğretebilmektir.
    Aşağıdaki örnekte Gamer nesne örneklerinin tutulduğu listenin sıralama işlemini yapabilmesi için bir karşılaştırma işlevinin
    öğretilmesi gösterilmektedir.

    Bunun için Sort metodunun detaylarına bakılabilir. Sort metodunun bir versiyonu IComparer arayüzü ile çalışır.
    Dolayısıyla kendi IComparer uyarlamamızı yazarak sıralama işleminin kendi istediğimiz şekilde yapılmasını sağlayabiliriz.
*/

internal class Program
{
    static void Main()
    {
        var gamers = GetGamers();
        gamers.Sort(new CompareByTotalPointAsc());
        Console.WriteLine("Sort Ascending by Total Point");
        WriteToConsole(gamers);

        gamers.Sort(new CompareByTotalPointDesc());
        Console.WriteLine("Sort Descending by Total Point");
        WriteToConsole(gamers);
    }

    static void WriteToConsole(List<Gamer> gamers)
    {
        foreach (var gamer in gamers)
        {
            Console.WriteLine($"{gamer.Id} {gamer.Nickname} {gamer.TotalPoint}");
        }
    }

    static List<Gamer> GetGamers()
    {
        return new List<Gamer>{
            new(){
                Id=1,
                Nickname="Hatuna Matata",
                TotalPoint=90.20,
                IsActive=true
            },
            new(){
                Id=2,
                Nickname="Hiper Maryo Bro",
                TotalPoint=75.40,
                IsActive=true
            },
            new(){
                Id=3,
                Nickname="Sega San",
                TotalPoint=80.10,
                IsActive=true
            },
            new(){
                Id=4,
                Nickname="Veroni-K",
                TotalPoint=59.50,
                IsActive=true
            },
            new(){
                Id=5,
                Nickname="Veroni-K",
                TotalPoint=100.89,
                IsActive=true
            },
            new() {
                Id=6,
                Nickname="Ini Mini Junior",
                TotalPoint=30.56,
                IsActive=true
            }
        };
    }
}

class CompareByTotalPointAsc
    : IComparer<Gamer>
{
    public int Compare(Gamer? gamer1, Gamer? gamer2)
    {
        if (gamer1 == null || gamer2 == null)
        {
            throw new NullReferenceException();
        }
        return gamer1.TotalPoint.CompareTo(gamer2.TotalPoint);
    }
}

class CompareByTotalPointDesc
    : IComparer<Gamer>
{
    public int Compare(Gamer? gamer1, Gamer? gamer2)
    {
        if (gamer1 == null || gamer2 == null)
        {
            throw new NullReferenceException();
        }
        return gamer2.TotalPoint.CompareTo(gamer1.TotalPoint);
    }
}

class Gamer
{
    public int Id { get; set; }
    public string Nickname { get; set; } = "Anonymous";
    public double TotalPoint { get; set; }
    public bool IsActive { get; set; }
}