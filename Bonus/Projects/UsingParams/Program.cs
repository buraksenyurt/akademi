/*
    Bazı hallerde bir metoda n sayıda parametre inmesi istenebilir ama kodu yazarken kaç parametre atılacağı bilinmeyebilir.
    Bu gibi durumlarda params kullanımı oldukça avantajlıdır. 
    Console sınıfının WriteLine metodu bunun güzel örneklerinden birisidir.
    Aşağıdaki kodlarda params kullanımı için bazı örnekler yer almaktadır.
*/
namespace UsingParams;

class Program
{
    static void Main()
    {
        var total = Utility.DoubleSum(1, 3, 5, 7, 9);
        Console.WriteLine(total);

        Utility.DoubleSum(3, 5, 7, 11, 13, 17, 19);
        Console.WriteLine(total);

        Utility.Writer("Bugün günlerden, ", DateTime.Now, "Main Program'da ", "Program.cs içerisindeyim.", true, Math.PI);

        var perimeters = Utility.CalcPerimeters(new Rectangle(1, 5), new Rectangle(2.5, 6.3));
        foreach (var perimeter in perimeters)
        {
            Console.WriteLine(perimeter);
        }
    }
}

/// <summary>
/// Yardımcı fonksiyonlar içeren sınıftır
/// </summary>
public class Utility
{
    /// <summary>
    /// N sayıda sayının karelerinin toplamını bulur
    /// </summary>
    /// <param name="numbers">Sayılar</param>
    /// <returns>Kareler toplamı</returns>
    public static int DoubleSum(params int[] numbers)
    {
        var total = 0;
        foreach (var number in numbers)
        {
            total += number * number;
        }
        return total;
    }

    /// <summary>
    /// Pratik terminal yazıcısı. 
    /// Gelen nesneleri string olarak aralarına virgül koyup ekrana basar.
    /// </summary>
    /// <example>
    /// Örnek bir kullanım aşağıdaki gibidir.
    /// <code>
    /// Utility.Writer("Bugün günlerden, ", DateTime.Now, "Main Program'da ", "Program.cs içerisindeyim.", true, Math.PI);
    /// </code>
    /// </example>
    /// <param name="expressions">Ekrana bastırılmak istenen ifadeler</param>
    public static void Writer(params object[] expressions)
    {
        foreach (var expression in expressions)
        {
            Console.Write($"{expression},");
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Dörtgenlerin çevrelerini hesaplar
    /// 
    /// Parametre olarak gelen dörtgenlerin her birinin çevresini hesaplar,
    /// bulunan değerleri dizide toplar.
    /// </summary>
    /// <param name="rectangles">Çevre değerlerinin listesi</param>
    /// <returns>Çevre değerlerinin listesi</returns>
    public static double[] CalcPerimeters(params Rectangle[] rectangles)
    {
        var perimeters = new double[rectangles.Length];
        for (int i = 0; i < perimeters.Length; i++)
        {
            perimeters[i] = rectangles[i].Perimeter();
        }
        return perimeters;
    }
}

public class Rectangle
{
    public double Width { get; set; }
    public double Height { get; set; }
    public Rectangle(double w, double h)
    {
        Width = w;
        Height = h;
    }
    public double Perimeter()
    {
        return 2 * (Width + Height);
    }
}
