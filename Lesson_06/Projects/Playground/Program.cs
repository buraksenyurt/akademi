namespace Playground;

using System;

class Program
{
    static void Main(string[] args)
    {
        Manager workItemManager = new();
        workItemManager.Seed();
        var workItems = workItemManager.GetWorkItems();
        // foreach (var wi in workItems)
        // {
        //     Console.WriteLine($"{wi.Title}");
        // }

        // Yüksek öncelikli işlerimizi listeyelim
        Console.WriteLine("*** Yüksek öncelikli işler ***");
        // workItems koleksiyonundaki her bir WorkItem nesnesini wi değişkeni ile ele al
        foreach (var wi in workItems)
        {
            // O anki WorkItem nesne örneğinin önceliği yüksek mi kontrol et
            if (wi.Priority == Priority.High)
            {
                Console.WriteLine($"{wi.Title} ({wi.Size})");
            }
        }

        // Saatlik işlerimizi listeleyelim
        // \n new line anlamındadır ve bir alt satıra geçildikten sonra başlık yazılır
        Console.WriteLine("\n*** Saatlik işler listesi ***");
        // Generic List koleksiyonu diziler gibi indeksleyici operatörüne sahiptir
        // dolayısıyla workItems[i] ile i indeksli sıradaki WorkItem nesnesine erişilebilir.
        for (int i = 0; i < workItems.Count; i++)
        {
            // Saat cinsinden bir WorkItem ise
            if (workItems[i].DurationType == Duration.Hour)
            {
                Console.WriteLine($"{workItems[i].Title} ({workItems[i].Size})");
            }
        }

        // Saatlik işlerimizin toplam süresini bulalım
        Console.WriteLine("\n*** Saatlik işlerin toplam süresi ***");
        var totalHour = 0;
        // Yine tüm work item'ları dolaş
        foreach (var wi in workItems)
        {
            // Eğer o anki work item nesnesinin DurationType değeri Hour ise
            if (wi.DurationType == Duration.Hour)
            {
                // güncel Duration değerini totalHour değişkenine ekle
                totalHour += wi.Duration; // totalHour = totalHour + wi.Duration ile aynı anlamdadır.
            }
        }
        Console.WriteLine($"Saatlik işler için toplam ayrılan süre {totalHour} saattir");

        // Önceliği normal olan işlerimizde gün bazlı olanları listeleyelim
        Console.WriteLine("\n*** Önceliği normal olan işlerden günlük bazlı olanlar ***");
        foreach (var wi in workItems)
        {
            // && and operatörünü kullanıyoruz. || bu da veya operatörü.
            if (wi.Priority == Priority.Standard && wi.DurationType == Duration.Day)
            {
                Console.WriteLine($"{wi.Title} ({wi.Size})");
            }
        }

        // En uzun başlıklı işimizi bulup ekrana yazdıralım
        Console.WriteLine("\n*** En uzun başlıklı işimi ***");
        var longestTitle = workItems[0].Title;
        for (int i = 1; i < workItems.Count; i++)
        {
            // Console.WriteLine($"'{workItems[i].Title}' ({workItems[i].Title.Length})");
            if (workItems[i].Title.Length >= longestTitle.Length)
            {
                longestTitle = workItems[i].Title;
            }
        }
        Console.WriteLine($"En uzun başlık '{longestTitle}' ve {longestTitle.Length} karakter.");

        // Yüksek öncelikli işler için ayırdığımız sürelerin toplamını gün bazında hesap edelim

        // Large ve X Large olan işlerin önceliklerini listeyelim
    }
}
