/*
    Reflection .Net tarafında ileri seviye konulardan birisidir.

    Genellikle .Net tiplerini çalışma zamanında analiz etmek veya referans edilmemiş nesneleri runtime'da örnekleyip,
    fonksiyonelliklerini işletmek gibi durumlarda kullanılır.

    Bu örnekteki amaç CommonLib.dll içerisindeki WindowManager sınıfının, CreateSplashScreen metodunu çağırmaktır.
    Ancak CommonLib bu projeye referans edilmiş değildir. Dolayısıyla runtime' da WindowManager sınıfının ilgili
    metodunun yine runtime'da oluşturulacak bir Window nesne örneği ile işletilmesi gerekiyor.

    Not: Örneğin kolayca işletilmesi için CommonLib.dll bu projenin olduğu klasöre kopyalanarak kullanılmıştır.

*/
using System.Reflection;

namespace UsingReflections;

class Program
{
    static void Main(string[] args)
    {
        var asmbly = Assembly.LoadFrom(@"CommonLib.dll");
        Console.WriteLine($"Assembly Fullname {asmbly.FullName}");

        Console.WriteLine($"\nAll types from {asmbly.GetName().Name}");
        foreach (var t in asmbly.GetTypes())
        {
            Console.WriteLine($"{t.FullName}");
        }

        Console.WriteLine($"\nAll classes from {asmbly.GetName().Name}");
        foreach (var t in asmbly.GetTypes().Where(t => t.IsClass))
        {
            Console.WriteLine($"{t.FullName}");
        }

        Console.WriteLine($"\nGet exported types and members from {asmbly.GetName().Name} (Only Classes)");
        foreach (var t in asmbly.GetExportedTypes().Where(t => t.IsClass && t.IsPublic))
        {
            Console.WriteLine($"{t.FullName}");
        }

        Console.WriteLine("Exported Types Members");
        var classes = asmbly.GetExportedTypes().Where(t => t.IsClass);
        foreach (var c in classes)
        {
            Console.WriteLine($"{c.Name} members");
            foreach (var m in c.GetMembers())
            {
                Console.WriteLine($"\t{m.Name}\t{m.MemberType}");
            }
        }

        // Window nesnesi örnekleme ve metod çağırma işlevleri eklenecek
    }
}
