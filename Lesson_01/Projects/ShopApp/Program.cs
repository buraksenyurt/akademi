namespace ShopApp;

class Program
{
    static void Main()
    {
        // Ürün (Product)
        // Sepet (Basket)
        // Satın Alma, Kredi Kartı ile Ödeme

        // Bir ürünün özellikleri neler olabilir?
        // Primitive Types
        // Primitive tiplerin tamamı aslında .Net Framework içerisinde System
        // isim alanındaki bir tipe(type) karşılık gelir.
        // Yani string aslında System.String sınıfı ile ifade edilir.
        // Veya int, Int32 struct türü ile ifade edilir.
        decimal price = 999.50M;
        string productNumber = "PRD-EL-100-991";
        string color = "Blue"; // metin katarı (string veri tipi iyidir hoştur ama pahalı bir nesnedir. Neden pahalı bir veri tipidir?)
        char code = 'B'; // karakter
        int stockLevel = 50;
        bool onSale = true;
        short averagePoint = 5;
        float width = 3.14F;
        Category productCategory = Category.Book;
        // var ile yapılan tanımlamalarda eşitliğin sağ tarafındaki değere göre sol taraftaki tip tahmin edilir.
        var exponent = 2.7;
        var currentCategory = Category.Electronic;

        // Ürünün bazı bilgilerini input olarak almak istiyoruz.
        Console.WriteLine("Lütfen ürünün adını giriniz");
        // Console sınıfının ReadLine metodu ile terminalden girdi alıp
        // bir değişkene atayabiliriz
        var productName = Console.ReadLine();
        Console.WriteLine("Ürünün adı {0}", productName);

        Console.WriteLine("Ürünün fiyatını giriniz");
        var unitPrice = Convert.ToDecimal(Console.ReadLine()); // Eşitliğin sağ tarafından gelen bilgi Convert.ToDecimal çağrısı ile decimal türüne çevrilebilir
        /* Yukarıdaki ifade tehlikelidir!!!

            Lütfen ürünün adını giriniz
            Monitör
            Ürünün adı Monitör
            Ürünün fiyatını giriniz
            ikibin elli
            Unhandled exception. System.FormatException: The input string 'ikibin elli' was not in a correct format.
            at System.Number.ThrowOverflowOrFormatException(ParsingStatus status, ReadOnlySpan`1 value, TypeCode type)
            at System.Convert.ToDecimal(String value)
            at ShopApp.Program.Main() in /home/burakselim/Development/akademi/Lesson_01/Projects/ShopApp/Program.cs:line 38
        */
        Console.WriteLine("Bu değişkenin tipi {0} dır", unitPrice.GetType());
        Console.WriteLine($"Ürünün fiyatı {unitPrice}");
        unitPrice += 10.5M;
        // unitPrice = unitPrice + 10.50; // Bu durumda ekrana 190.5010.5 TL yazar. Aslında 201.

        Console.WriteLine($"Ürünün adı {productName} ({unitPrice} TL)");

        Console.WriteLine($"int aslında {23.GetType()} türündedir. Int32'nin minimum değeri {Int32.MinValue} maksimum değeri ise {Int32.MaxValue}");
        Console.WriteLine($"unsigned int32 için minimum değer {UInt32.MinValue} maksimum değer ise {UInt32.MaxValue} dur");
    }
}

/*
        Bir ürünün kategorsini şimdilik Enum sabiti gibi kullandık.
        Ama ürün kategorileri hep değişebilir ve farklı özellikler de barındırabilir.
        Örneğin bir kategorinin kısa tanımı ve uzun açıklaması olabilir ya da o kategoride 
        kaç ürün tutulduğu bilgisini içerebilir. Hatta bir kategori başka bir kategorinin
        alt kategorisi olabilir. Bu yüzden enum veri tipi belki de kategorileri tutmak için
        çok da uygun değildir.
    */
enum Category
{
    Electronic,
    Book,
    Game
}

// ProductColor prdColor = ProductColor.Green;

// enum ProductColor
// {
//     Red,
//     Green,
//     Blue,
//     Gray
// }