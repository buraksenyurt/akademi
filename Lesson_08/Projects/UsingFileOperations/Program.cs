using System.Text;

namespace UsingFileOperations;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hatırlamak isteğin notları yazabilirsin? Çıkmak için Exit yazın.");
        StringBuilder sBuilder = new StringBuilder();
        while (true)
        {
            Console.WriteLine("Notunu yazar mısın?");
            var note = Console.ReadLine();
            Console.WriteLine($"'{note}' yazdın.");
            if (note.ToLower() == "exit")
            {
                WriteDataWithStream(sBuilder.ToString());
                break;
            }
            sBuilder.AppendLine(note);
        }
    }

    static void WriteDataWithStream(string content)
    {
        // Path.Combine ile birden fazla klasör yolu birleştirilebilir
        // Environmen.CurrentDirectory özelliği, uygulamanın çalıştığı klasörü döndürür
        var targetFile = Path.Combine(Environment.CurrentDirectory, "Products.dat");
        // targerFile'ı ekleme modunda yazma amacıyla kullanacak FileStream nesnesi örneklenir
        FileStream fs = new FileStream(targetFile, FileMode.Append, FileAccess.Write);
        StreamWriter streamWriter = new StreamWriter(fs);
        streamWriter.WriteLine(content);
        streamWriter.Flush(); // buffer'ı beklemeden tüm içeriği yaz
        streamWriter.Close(); // streamWriter kaynağını kapatır
        fs.Close(); // fileStream kaynağını kapatır
    }
}
