namespace Playground;

using System;

class Program
{
    /*
        Aşağıdaki üç metoda baktığımızda ne görüyoruz ?
        Bu üç metodda WorkItem tipinden parametre alıyor ve geriye bool değer döndürüyor.
        Bu üç metodun işini yapacak tek bir metod yazabilir miyim?

        Tanımladığımız temsilci tipi (delegate), GetWorkItems' ın yeni versiyonu ve lambda operatörü sayesinde
        aşağıdaki gibi metotlar tanımlamamıza gerek kalmadı.
    */
    // static bool IsHighPriority(WorkItem workItem)
    // {
    //     return workItem.Priority == Priority.High;
    // }
    // static bool IsHourDuration(WorkItem workItem)
    // {
    //     return workItem.DurationType == Duration.Hour;
    // }
    // static bool IsStandardAndDay(WorkItem workItem)
    // {
    //     return workItem.Priority == Priority.Standard && workItem.DurationType == Duration.Day;
    // }
    static void Main(string[] args)
    {
        Manager workItemManager = new();
        workItemManager.Seed();
        // Aşağıdaki ifadede GetWorkItems metoduna IsHighPriorty fonksiyonu parametre olarak atanmıştır.
        //var query_1 = workItemManager.GetWorkItems(IsHighPriority);
        // Yukarıdaki gibi her blok için bir metod yazıp göndermek yerine
        // lambda operatörünü ( => işareti) kullanıp metoda bir fonksiyonun bloğunu isimsiz(anonymous method)
        // olarak da gönderebiliriz
        var query_1 = workItemManager.GetWorkItems(wi => wi.Priority == Priority.High);
        WriteToConsole(query_1);

        //var query_2 = workItemManager.GetWorkItems(IsHourDuration);
        var query_2 = workItemManager.GetWorkItems(wi => wi.DurationType == Duration.Hour);
        WriteToConsole(query_2);

        //var query_3 = workItemManager.GetWorkItems(IsStandardAndDay);
        var query_3 = workItemManager.GetWorkItems(wi => wi.Priority == Priority.Standard && wi.DurationType == Duration.Day);
        WriteToConsole(query_3);

        Console.WriteLine("\nLarge olup Title bilgisi 60 karakterden uzun olanlar");
        var query_4 = workItemManager.GetWorkItems(wi => wi.Size == Size.L && wi.Title.Length > 60);
        WriteToConsole(query_4);

        // .Net içerisinde LINQ metotlarını kullanarak da yukarıdaki gibi ve daha gelişmiş sorguları nesne dizileri üzerine yapabiliriz
        // LINQ içerisinde var olan pek çok tip için genişletme metotlar vardır (Where, singleOrDefault, Count, Select, OrderBy vb)
        var workItems = workItemManager.GetWorkItems();
        Console.WriteLine("\n***O harfi ile başlayan işlerin süre türüne göre sıralı listesi***");
        var query_5 = workItems.Where(wi => wi.Title.StartsWith('O')).OrderBy(wi => wi.DurationType).ToList();
        WriteToConsole(query_5);

        // Yukarıdaki sorgunun benzeri aşağıdaki gibi de yazılabilir.
        Console.WriteLine("\n***O harfi ile başlayan işlerin süre türüne göre sıralı listesi(LINQ ifadesi ile)***");
        var query_6 = from wi in workItems
                      where wi.Title.StartsWith('O')
                      orderby wi.DurationType
                      select wi; // burada isimsiz tip de döndürebiliriz (Anonymous Type)

        WriteToConsole(query_6.ToList());

        #region Önceki sürüm

        // var workItems = workItemManager.GetWorkItems();
        // // foreach (var wi in workItems)
        // // {
        // //     Console.WriteLine($"{wi.Title}");
        // // }

        // // Yüksek öncelikli işlerimizi listeyelim
        // Console.WriteLine("*** Yüksek öncelikli işler ***");
        // // workItems koleksiyonundaki her bir WorkItem nesnesini wi değişkeni ile ele al
        // foreach (var wi in workItems)
        // {
        //     // O anki WorkItem nesne örneğinin önceliği yüksek mi kontrol et
        //     // if (wi.Priority == Priority.High)
        //     // {
        //     //     Console.WriteLine($"{wi.Title} ({wi.Size})");
        //     // }
        //     if (IsHighPriority(wi))
        //     {
        //         Console.WriteLine($"{wi.Title} ({wi.Size})");
        //     }
        // }

        // // Saatlik işlerimizi listeleyelim
        // // \n new line anlamındadır ve bir alt satıra geçildikten sonra başlık yazılır
        // Console.WriteLine("\n*** Saatlik işler listesi ***");
        // // Generic List koleksiyonu diziler gibi indeksleyici operatörüne sahiptir
        // // dolayısıyla workItems[i] ile i indeksli sıradaki WorkItem nesnesine erişilebilir.
        // for (int i = 0; i < workItems.Count; i++)
        // {
        //     // // Saat cinsinden bir WorkItem ise
        //     // if (workItems[i].DurationType == Duration.Hour)
        //     // {
        //     //     Console.WriteLine($"{workItems[i].Title} ({workItems[i].Size})");
        //     // }
        //     if (IsHourDuration(workItems[i]))
        //     {
        //         Console.WriteLine($"{workItems[i].Title} ({workItems[i].Size})");
        //     }
        // }

        // // Saatlik işlerimizin toplam süresini bulalım
        // Console.WriteLine("\n*** Saatlik işlerin toplam süresi ***");
        // var totalHour = 0;
        // // Yine tüm work item'ları dolaş
        // foreach (var wi in workItems)
        // {
        //     // Eğer o anki work item nesnesinin DurationType değeri Hour ise
        //     if (wi.DurationType == Duration.Hour)
        //     {
        //         // güncel Duration değerini totalHour değişkenine ekle
        //         totalHour += wi.Duration; // totalHour = totalHour + wi.Duration ile aynı anlamdadır.
        //     }
        // }
        // Console.WriteLine($"Saatlik işler için toplam ayrılan süre {totalHour} saattir");

        // // Önceliği normal olan işlerimizde gün bazlı olanları listeleyelim
        // Console.WriteLine("\n*** Önceliği normal olan işlerden günlük bazlı olanlar ***");
        // foreach (var wi in workItems)
        // {
        //     // && and operatörünü kullanıyoruz. || bu da veya operatörü.
        //     // if (wi.Priority == Priority.Standard && wi.DurationType == Duration.Day)
        //     // {
        //     //     Console.WriteLine($"{wi.Title} ({wi.Size})");
        //     // }
        //     if (IsStandardAndDay(wi))
        //     {
        //         Console.WriteLine($"{wi.Title} ({wi.Size})");
        //     }
        // }

        // // En uzun başlıklı işimizi bulup ekrana yazdıralım
        // Console.WriteLine("\n*** En uzun başlıklı işimi ***");
        // var longestTitle = workItems[0].Title;
        // for (int i = 1; i < workItems.Count; i++)
        // {
        //     // Console.WriteLine($"'{workItems[i].Title}' ({workItems[i].Title.Length})");
        //     if (workItems[i].Title.Length >= longestTitle.Length)
        //     {
        //         longestTitle = workItems[i].Title;
        //     }
        // }
        // Console.WriteLine($"En uzun başlık '{longestTitle}' ve {longestTitle.Length} karakter.");

        // // Yüksek öncelikli işler için ayırdığımız sürelerin toplamını gün bazında hesap edelim

        // // Large ve X Large olan işlerin önceliklerini listeyelim

        #endregion
    }

    static void WriteToConsole(List<WorkItem> list)
    {
        foreach (var wi in list)
        {
            Console.WriteLine($"{wi.Id}- {wi.Title}");
        }
    }
}
