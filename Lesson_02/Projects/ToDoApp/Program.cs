namespace ToDoApp;

class Program
{
    static void Main(string[] args)
    {
        // Görev No #1 Haftasonu 3 saat C# çalışacağım
        // Görev No #2 Akşam odamı toparlayacağım
        // Görev No #3 Bu sefe İngilizce sınavından A1 seviyesinde derece yapacağım

        // İçerikteki özellikler: Zaman, benzersiz görev numaraları, ne yapılacağı bilgisi, koşula bağlı hedefler
        var taskId = 1;
        var title = "C# çalışmak";
        var duration = 3;
        var durationType = DurationType.Hour;
        var taskSize = TaskSize.S; // T-Shirt Size tipinden büyüklük

        Console.WriteLine("Merhaba. Ben görev listesi yardımcın.");
        Console.WriteLine("Çıkmak için q/Q tuşlarına sonrasında Enter'a basın.");
        int id = 0;

        // koşulu sürekli true olarak belirlediğimizden bir sonsuz döngü oluşur.
        // Bu örnek özelinde, kullanıcı q veya Q yazarsa döngüden çıkılır
        while (true)
        {
            Console.WriteLine("Görevi yazın");
            title = Console.ReadLine();

            // Girilen bilgiyi ToUpper fonksiyonu ile büyük harfe çeviriyoruz

            if (title.ToUpper() == "Q") // tek tırnak içerisinde yazılan karakterler char tipindendir
            {
                Console.WriteLine("Görüşmek üzere kendine iyi bak");
                break; // Q girilmişse break komutu döngüden çıkılmasını sağlar.
            }
            else // Q dışında bir şey girildiyse çalışan yer
            {
                id += 1; // Görev numarsını 1 artır
                Console.WriteLine("İşin süresini giriniz");
                var durationInput = Console.ReadLine();
                // duration = Convert.ToInt32(durationInput);
                // Convert metotları dönüştürme işlemi başarılı olmazsa çalışma zamanına Exception fırlatır.
                // Kontrol edilmeye exception'lar programın çökmesine(crash) sebebiyet verir.
                // Unhandled exception. System.FormatException: The input string 'birbuçuk saat' was not in a correct format.

                if (!Int32.TryParse(durationInput, out duration)) // girilen bilgi int türüne çevrilemez ise
                {
                    Console.WriteLine("İşin süresi tam sayı olmalıdır");
                    continue; // döngü bir sonraki iterasyondan devam etsin
                }
                //TODO@Everyone Aşağıdaki if...else yapısı yerine switch bloğu kullanabilir miyiz?
                Console.WriteLine("Süre türü nedir? (H)our, (D)ay, (M)onth, (Y)ear");
                var durationTypeInput = Console.ReadLine();
                if (durationTypeInput.ToUpper() == "H")
                {
                    durationType = DurationType.Hour;
                }
                else if (durationTypeInput.ToUpper() == "D")
                {
                    durationType = DurationType.Day;
                }
                else if (durationTypeInput.ToUpper() == "M")
                {
                    durationType = DurationType.Month;
                }
                else if (durationTypeInput.ToUpper() == "Y")
                {
                    durationType = DurationType.Year;
                }
                else
                {
                    Console.WriteLine("Geçerli bir süre türü girmedin");
                    continue;
                }

                Console.WriteLine("İşin büyüklüğü sizce nedir? (S)mal, (M)edium, (L)arge, (X)Large");
                var taskSizeInput = Console.ReadLine();
                if (taskSizeInput.ToUpper() == "S")
                {
                    taskSize = TaskSize.S;
                }
                else if (taskSizeInput.ToUpper() == "M")
                {
                    taskSize = TaskSize.M;
                }
                else if (taskSizeInput.ToUpper() == "L")
                {
                    taskSize = TaskSize.L;
                }
                else if (taskSizeInput.ToUpper() == "X")
                {
                    taskSize = TaskSize.XL;
                }
                else
                {
                    Console.WriteLine("Girdiğin iş büyüklüğü geçerli değil");
                    continue;
                }

                Console.WriteLine("Tebrikler. Görev sisteme yazıldı");
                Console.WriteLine($"{id} - {title}({taskSize}) - {duration} {durationType}");
            }
        }

        // for(;;){

        // }
    }
}
enum DurationType
{
    Hour,
    Day,
    Month,
    Year
}
enum TaskSize
{
    S,
    M,
    L,
    XL
}
enum TaskState{
    Todo,
    InProgress,
    Completed,
    Undone
}

// Aslında uygulamanın ana konusu olan görev(Task) bir sınıf olarak tasarlanabilir.
// Aşağıdaki sınıfı hem okunabilir hem de yazılabilir tipte özellikleri var.
// Id, Title, DurationType, Duration, TaskSize bir görev nesnesinin niteliklerini ifade eder. Auto Property formatında yazılmışlardır.
// Burada sistem içinde dolaşıma tabii olacak kendi veri modelimizi tanımlamış oluyoruz.
class Task
{
    public int Id { get; set; } 
    public string Title { get; set; }
    public DurationType DurationType { get; set; }
    public byte Duration { get; set; }
    public TaskSize TaskSize { get; set; }
    // Bir Task'ın güncel durumu(state bilgisi) her an okunabilir,
    // sadece belli bir aksiyon gerçekleştiğinde değiştirilebilir.
    // Bu yüzden read only tanımlanmıştır.
    public TaskState State { get; } // Sadece get var ise bu read-only(yalnızca okunabilir) anlamındadır.
}