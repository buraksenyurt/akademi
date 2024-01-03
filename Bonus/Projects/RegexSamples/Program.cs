/*
    Metinsel bir ifadenin belli kurallara göre yazıldığının doğrulanmasında veya 
    bir metin içeriğinde belli bir şablona uyan elemanların aranmasında Regex ifadelerine sıklıkla başvurulur.

    Bir gerçek hayat senaryosu olarak şunu ifade edebiliriz. Bir Solution içerisindeki kod dosyalarında
    sınıf adı belirlenen standartlara uymayanların tespit edilmesinde örneğin Regex kullanılabilir.

    Daha çok doğrulama(Validation) operasyonlarında başvurulur. Örneğin kullanıcının girdiği bilginin geçerli
    bir url,mail,ssn,tckn vb olup olmadığının tespitinden kullanılabilir.

    Aşağıdaki kod parçasında bazı regex ifadelerinin çalıştırılmasına ait işlemler söz konusudur.
*/
using System.Text.RegularExpressions;

namespace RegexSamples;

class Program
{
    static void Main()
    {
        var someEmails = new string[] {
                "john@doe.com"
                , "john.doe@gmail.com"
                , "some_email", "1234"
                , ""
                ,"thresisnoEMAILaddressinthisroom"
            };
        foreach (var email in someEmails)
        {
            Console.WriteLine("{0} {1}", email, RegexUtility.IsValidEmailAddress(email) ? "is valid" : "is not valid");
        }

        var someIpAddress = new string[]{
            "127.0.0.1",
            "0.0.0.0",
            "192.168.1.1",
            "300,300.300.300",
            "....",
            "012345",
            "8080",
            "8.8.8.8"
        };

        foreach (var ipAddress in someIpAddress)
        {
            Console.WriteLine("'{0}' {1}", ipAddress, RegexUtility.IsValidIP(ipAddress) ? "is valid" : "is not valid");
        }

        var motto = "it is a lovely day, isn't it!";
        Console.WriteLine(motto.ToUpperOnlyFirstLetter());

        string sampleScript = @"
            public class Calculator {
                private double pi;
                public double Sum(double x,double y) 
                { 
                    return x + y;
                }                
                static void GetRandomNumber() 
                {                     
                }

                private string GetHelp(string command) {
                    
                }
            }

            public interface IShape{
                string Title { get; }
            }
        ";
        var methodNames = RegexUtility.FindMethodNames(sampleScript);
        foreach (var mn in methodNames)
        {
            Console.WriteLine(mn);
        }

    }
}

/// <summary>
/// Bazı yardımcı Regex ifadelerini içeren sınıftır.
/// </summary>
public static class RegexUtility
{
    /// <summary>
    /// Girilen bilginin geçerli bir e-mail adresi formatında olup olmadığını kontrol eder
    /// </summary>
    /// <param name="mailAddress">Kontrol edilecek mail adresi</param>
    /// <returns>Geçerli ise true değilse false</returns>
    public static bool IsValidEmailAddress(string mailAddress)
    {
        var pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        return Regex.IsMatch(mailAddress, pattern);
    }

    /// <summary>
    /// Girilen bir IP adresi bilgisinin geçerli olup olmadığını kontrol eder
    /// </summary>
    /// <param name="ipAddress">Kontrol edilecek IP adresi</param>
    /// <returns>Geçerli ise true değilse false</returns>
    public static bool IsValidIP(string ipAddress)
    {
        var pattern = @"\b(?:(?:2(?:[0-4][0-9]|5[0-5])|[0-1]?[0-9]?[0-9])\.){3}(?:(?:2([0-4][0-9]|5[0-5])|[0-1]?[0-9]?[0-9]))\b";
        return Regex.IsMatch(ipAddress, pattern);
    }

    /// <summary>
    /// Gelen metinsel içerikteki kelimelerin sadece ilk harflerini büyüğe çevirerek döndüren fonksiyondur
    /// </summary>
    /// <param name="input">Girdi metni</param>
    /// <returns>Baş harflerin büyük formata çevrildiği versiyon</returns>
    public static string ToUpperOnlyFirstLetter(this string input)
    {
        string pattern = @"\b\w";
        return Regex.Replace(input, pattern, c => c.Value.ToUpper());
    }

    /// <summary>
    /// Verilen kod içeriğinde metot adlarını bulur.
    /// 
    /// Kod içeriğinde metodların tek satırda tanımlandığı kabul edilmiştir.
    /// </summary>
    /// <param name="content">Kod içeriği</param>
    /// <returns>Metot adları</returns>
    public static IEnumerable<string> FindMethodNames(string content)
    {
        var methodNames = new List<string>();
        string pattern = @"\b(public|private|protected|internal|static)?\s+[\w<>\[\]]+\s+(\w+)\s*\(";

        MatchCollection matches = Regex.Matches(content, pattern);

        foreach (Match match in matches.Cast<Match>())
        {
            if (match.Groups.Count >= 3)
            {
                methodNames.Add(match.Groups[2].Value);
            }
        }

        return methodNames;
    }
}
