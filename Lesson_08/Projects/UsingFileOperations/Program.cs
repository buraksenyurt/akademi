using System.Text;

namespace UsingFileOperations;

class Program
{
    static void Main()
    {
        // Console.WriteLine("Hatırlamak isteğin notları yazabilirsin? Çıkmak için Exit yazın.");
        // StringBuilder sBuilder = new StringBuilder();
        // while (true)
        // {
        //     Console.WriteLine("Notunu yazar mısın?");
        //     var note = Console.ReadLine();
        //     Console.WriteLine($"'{note}' yazdın.");
        //     if (note.ToLower() == "exit")
        //     {
        //         WriteDataWithStream(sBuilder.ToString());
        //         break;
        //     }
        //     sBuilder.AppendLine(note);
        // }

        Console.WriteLine("İçeriğini görmek istediğiniz dosya adını yazın");
        var sourceFile = Path.Combine(Environment.CurrentDirectory, Console.ReadLine());
        try
        {
            var fileContent = ReadDataWithStream(sourceFile);
            Console.WriteLine(fileContent);
        }
        catch (FileNotFoundException excp)
        {
            // try bloğunda spesifik olarak FileNotFoundException oluşura bu blok çalışır ve alttaki Exception bloğu çalışmaz.
            Console.WriteLine($"Belirtilen dosya sistemde bulunamadığı için program sonlanacaktır.\n{excp.Message}");
        }
        catch (Exception excp)
        {
            // En genel Exception sınıfıdır hatta tüm Exception tiplerinin atasıdır.
            // try bloğunda oluşan ama yukarıdaki Exception bloğu gibi spesifik olarak ele almadığımız tüm diğer exception'ların 
            // bu blok çalışır
            Console.WriteLine($"Program '{excp.Message}' sebebiyle sonlanacaktır.");
        }
        finally // finally bloğu try bloğunda hata olsa da olmasa da çalışır.
        {
            Console.WriteLine("Program sonlanıyor.");
        }
        Console.WriteLine("Teşekkürler, görüşmek üzere.");
    }

    static string ReadDataWithStream(string sourceFile)
    {
        // FileNotFoundException'dan kaçınmak için sourceFile'ın var olup olmadığı kontrol edilebilir.
        var sBuilder = new StringBuilder();
        using FileStream fs = new(sourceFile, FileMode.Open, FileAccess.Read);
        using StreamReader streamReader = new(fs);
        streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
        var line = streamReader.ReadLine();
        while (line != null)
        {
            sBuilder.AppendLine(line);
            line = streamReader.ReadLine();
        }
        return sBuilder.ToString();
    }

    static void WriteDataWithStream(string content)
    {
        // Path.Combine ile birden fazla klasör yolu birleştirilebilir
        // Environmen.CurrentDirectory özelliği, uygulamanın çalıştığı klasörü döndürür
        var targetFile = Path.Combine(Environment.CurrentDirectory, "Products.dat");
        // targerFile'ı ekleme modunda yazma amacıyla kullanacak FileStream nesnesi örneklenir
        // using bloğu ile nesnenin dispose metotu, blok sonuna gelindiğinde otomatik olarak çalıştırılır
        // ve kullandığı sistem kaynakları da varsa bunlar iade edilir.
        // using bloğunun kullanılabilmesi için nesnenin (örneğin FileStream veya StreamWriter)
        // IDiposable arayüzünü(interface) implemente etmiş olması gerekir.
        using FileStream fs = new(targetFile, FileMode.Append, FileAccess.Write);
        using StreamWriter streamWriter = new(fs);
        streamWriter.WriteLine(content);
        streamWriter.Flush(); // buffer'ı beklemeden tüm içeriği yaz
                              // streamWriter.Close(); // streamWriter kaynağını kapatır
                              // fs.Close(); // fileStream kaynağını kapatır
    }
}
