namespace UsingExtensions;

class Program
{
    static void Main(string[] args)
    {
        int point = 32;
        /*
            Normal şartlar altında Int32 tipinin IsLessThan veya IsGreaterThan vb
            metotları yok. Ancak genişletme metotları ile (extension methods)
            Int32 türüne yeni fonksiyonellikler dahil edilebilir.
            Aşağıda bunlara ait örnek kullanımlar görmektesiniz.
        */
        Console.WriteLine("Girilen değer 50den büyük mü?");
        Console.WriteLine($"{point.IsGreaterThan(50)}");
        Console.WriteLine("Girilen değer 30dan küçük mü?");
        Console.WriteLine($"{point.IsLessThan(33)}");

        var sum = Algebra.Sum(3.14, 2.27);
        Console.WriteLine($"3.14 + 2.27 = {sum}");

        var motto = "It's a rainy day";
        
        Console.WriteLine($"{motto}\n{motto.WriteLovely('_')}");
        Console.WriteLine($"{motto}\n{motto.WriteLovely('*')}");
        Console.WriteLine($"{motto}\n{motto.WriteLovely(' ')}");
    }
}
/*
    Algebra statik tanımlamış bir sınıftır. Bu nedenle kullanmak için
    nesne örneği üretmeye gerek yoktur.
    Yani;

    Algebra einstein = new Algebra();

    gibi örneklenerek kullanılamaz.
    Üyelerine (members) doğrudan erişilebilir.

    Algebra.Sum(3.14,2.27); 
    
    gibi
*/
public static class Algebra
{
    public static double Sum(double x, double y)
    {
        return x + y;
    }
}
/*
    Extension method yazma kuralları nelerdir?

    Bu metotlar statik sınıflar içerisinde statik metotlar olarak yazılırlar.
    Statik sınıfların en önemli özelliği kullanılabilmeleri için nesne örneğine gereksinim duyulmamasıdır.

    Genişletme metodu hangi tipi genişleteceksek, ilk parametresi o tip olmalıdır 
    ve başında this anahtar kelimesi bulunmalıdır.
*/
public static class Int32Extensions
{
    public static bool IsLessThan(this int value, int limit)
    {
        return value < limit;
    }
    public static bool IsLessThanEqual(this int value, int limit)
    {
        return value <= limit;
    }

    public static bool IsGreaterThan(this int value, int limit)
    {
        return value > limit;
    }
    public static bool IsGreaterThanEqual(this int value, int limit)
    {
        return value >= limit;
    }
}

public static class StringExtensions
{
    public static string WriteLovely(this string expression, char seperator)
    {
        var result = string.Empty;

        // string ifadeler metin katarlarıdır ve aslında bir karakter dizisi olarak düşünelebilir
        // dolayısıyla aşağıdaki döngü expression değişkeni ile gelen metindeki her bir karakteri dolaşmak için kullanılır
        foreach (var c in expression)
        {
            result += $"{c}{seperator}";
        }

        return result;
    }
}
