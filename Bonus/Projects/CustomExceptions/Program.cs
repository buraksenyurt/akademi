/*
    Bu örnekte geliştirici tarafından tanımlı Exception türlerinin kullanımına ait bir örnek yer almaktadır.
    Ayrıca basit bir Regex kullanımı da söz konusudur.

    Kodda yer alan IPv4 sınıfı bir IP adresini saklamak üzere tasarlanmıştır.
    Yapıcı metot içerisinde gelen bilginin geçerli bir IP adresi olup olmadığı regex ifadesi ile kontrol edilmekte,
    sonrasında IP range değerlerine bakılmaktadır.

    Eğer geçersiz bir IP adresi girişi söz konusu ise çalışma zamanına InvalidIpException türünden bir istisna fırlatılmaktadır.
*/
using System.Text.RegularExpressions;

namespace CustomExceptions;

class Program
{
    static void Main()
    {
        try
        {
            var localhost = new IPv4("127.0.0.1");
            Console.WriteLine($"Localhost : {localhost}");

            var ipNew = new IPv4("192.168.1.1");
            Console.WriteLine($"Service Address I  : {ipNew}");

            var otherIp = new IPv4("202.168.15.168");
            Console.WriteLine($"Service Address II : {otherIp}");

            //var remoteIp = new IPv4("");

            // Alt satırdaki IP bilgisi geçersizdir ve çalışma zamanında Exception fırlatılmasına sebebiyet verir
            var invalidIp = new IPv4("300.400.15.168");
            Console.WriteLine($"Invalid Address : {invalidIp}");
        }
        catch (InvalidIpException excp)
        {
            /*
                StackTrace ile kod akışının hatanın fırlatıldığı yere kadar olan kısmı izlenebilir.
                Developer açısından önemli bilgiler içerir. Kod nereden hata alan kısma gelmiş,
                yol boyunca hangi metotları çağırmış gibi.
                StackTrace bilgisi alt satırdan üst satıra doğru okunur.
            */
            Console.WriteLine($"{excp.Message}\n{excp.StackTrace}");
        }
        Console.WriteLine("\nProgram sonu");
    }
}

/// <summary>
/// Dördüncü nesil IP adreslerini temsil eden sınıftır
/// </summary>
public class IPv4
{
    private readonly string _ipAddress;

    /// <summary>
    /// IP adresini oluşturan yapıcı metot
    /// </summary>
    /// <param name="ipAddress">IP adresi bilgisi</param>
    /// <exception cref="InvalidIpException">Geçersiz bir IP bilgisi olması halinde bu istisna fırlatılır</exception>
    public IPv4(string ipAddress)
    {
        if (!CheckAddress(ipAddress))
            throw new InvalidIpException(); // geçerli bir IP adresi söz konusu değilse, object user'ı bir exception fırlatarak cezalandırırız
        else
            _ipAddress = ipAddress;
    }

    /// <summary>
    /// IP Adresinin doğruluğunu kontrol eden fonksiyondur
    /// </summary>
    /// <param name="ipAddress">IP Adresi</param>
    /// <returns>IP Adresi geçerli ise true döner</returns>
    private bool CheckAddress(string ipAddress)
    {
        var regex = new Regex(@"^(\d{1,3}\.){3}\d{1,3}$");
        if (!regex.IsMatch(ipAddress)) return false;

        var segments = ipAddress.Split('.');
        foreach (var segment in segments)
        {
            if (int.TryParse(segment, out int value) && value >= 0 && value <= 255)
            {
                continue;
            }
            return false;
        }

        return true;
    }

    public override string ToString()
    {
        return _ipAddress.ToString();
    }
}

public class InvalidIpException
    : Exception // Bu sınıf Exception sınıfından türediği için try...catch bloklarında yakalanabilir
{
    public InvalidIpException()
        : base("Geçersiz IP adresi")
    {
    }
}