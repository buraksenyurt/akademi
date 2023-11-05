namespace hello_world;

// Program bir sınıftır
// Uygulamada Main metodunu içeren sınıflar genelde Program olarak isimlendirilir
class Program
{
    // Programın çalışmaya başladığı nokta/fonksiyon (Entry Point)
    // Main özel bir fonksiyondur. Genelde geriye değer döndürmez(void)
    // string[] args aslında n sayıda komut parametresi alabileceğimizi gösterir.
    // string[] metin tabanlı değişkenlerden oluşan bir dizidir(array)
    static void Main(string[] args)
    {
        // Console, System isim alanı(namespace) altında yer alan bir sınıftır(class)
        // WriteLine ise bu sınıfın bir metodudur. Bu örnekte parametre alır ve bunu ekrana yazdırır.
        Console.WriteLine("Hello, World!");
    } // Kod buraya indiğinde program (Main fonksiyonu sonlandığı için) sonlanır.
}