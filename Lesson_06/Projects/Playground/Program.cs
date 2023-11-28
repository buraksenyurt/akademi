namespace Playground;

using System;

class Program
{
    static void Main(string[] args)
    {
        Manager workItemManager = new();
        workItemManager.Seed();
        var workItems = workItemManager.GetWorkItems();
        foreach (var wi in workItems)
        {
            Console.WriteLine($"{wi.Title}");
        }
        //TODO@buraksenyurt Yapılacaklar aşağıdadır

        // Yüksek öncelikli işlerimizi listeyelim

        // Saatlik işlerimizi listeleyelim

        // Saatlik işlerimizin toplam süresini bulalım

        // Önceliği normal olan işlerimizinde gün bazlı olanları listeleyelim

        // Yüksek öncelikli işler için ayırdığımız sürelerin toplamını gün bazında hesap edelim

        // En uzun başlıklı işimizi bulup ekrana yazdıralım

    }
}
