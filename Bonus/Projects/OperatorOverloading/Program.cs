/*
    Aşağıdaki örnekte basit operator overloading konusu ele alınmaktadır. 
    Operator overloading bilinen operatörlerin varsayılan davranışlar dışında bizim belirlediğimiz şekilde hareket etmelerinin sağlanması için kullanılan bir tekniktir. 
    Dört işlem operatörlerinden karşılaştırma operatörlerine kadar birçok operatör istenirse yeniden yazılabilir.     
    Özellikle kendi türlerimiz için bazı senaryolarda operatörlerin yeniden yüklenmesi gerekebilir.

    Bazı operatörler için ters operatörlerin de yüklenmesi gerekir. Örneğin < operatörünü override edersek > operatörünün de override edilmesi gerekir.
*/

namespace OperatorOverloading;

class Program
{
    static void Main()
    {
        #region Sample #1

        var trinity = new Player(1, "Tirinity");
        var neo = new Player(2, "Neo");
        var raven = new Player(3, "Raven");

        neo++;
        trinity++;
        trinity++;
        raven++;
        raven++;

        Console.WriteLine($"Trinity point is {trinity.GetPoint()}");
        Console.WriteLine($"Neo point is {neo.GetPoint()}");

        if (trinity > neo)
        {
            Console.WriteLine("Trinity, Neo'ya göre daha üst seviye bir oyuncu");
        }
        else
        {
            Console.WriteLine("Neo, Trinity'ye göre daha üst seviye bir oyuncu");
        }

        if (trinity > raven)
        {
            Console.WriteLine("Trinity, Raven'a göre daha üst seviye bir oyuncu");
        }
        else if (trinity < raven)
        {
            Console.WriteLine("Raven, Trinity'ye göre daha üst seviye bir oyuncu");
        }
        else if (trinity == raven)
        {
            Console.WriteLine("Trinity ve Raven Eşit güçte oyuncular.");
        }
        #endregion Sample #1

        #region Sample #2

        var color1 = new Color(125, 0, 0, 0.5);
        var color2 = new Color(0, 125, 255, 0.75);
        var newColor = color1 + color2;
        Console.WriteLine(newColor);

        #endregion Sample #2
    }
}

/// <summary>
/// Oyuncu bilgilerini tutan nesnedir
/// </summary>
class Player
{
    private readonly int _id;
    private readonly string _name;
    private double _point;
    public Player(int id, string name)
    {
        _id = id;
        _name = name;
    }
    /// <summary>
    /// Oyuncunun güncel puan bilgisidir
    /// </summary>
    /// <returns>Double türünden puan bilgisidir</returns>
    public double GetPoint() => _point;

    /// <summary>
    /// Oyuncunun puanının 1 puan artırır
    /// </summary>
    /// <param name="player">Puanı artırılacak oyuncu nesnesidir</param>
    /// <returns>Puanı 1 birim artırılmış oyuncu nesnesidir</returns>
    public static Player operator ++(Player player)
    {
        player._point++;
        return player;
    }

    /// <summary>
    /// İki oyuncuyu puan bazında büyüktür(>) operatörüne göre karşılaştırır
    /// </summary>
    /// <param name="playerA">İlk oyuncu nesnesi</param>
    /// <param name="playerB">İkinci oyuncu nesnesi</param>
    /// <returns>İlk oyuncu puanı ikinci oyuncu puanından fazla ise true döner</returns>
    public static bool operator >(Player playerA, Player playerB) => playerA._point > playerB._point;

    /// <summary>
    /// İki oyuncuyu puan bazında büyüktür(<) operatörüne göre karşılaştırır
    /// </summary>
    /// <param name="playerA">İlk oyuncu nesnesi</param>
    /// <param name="playerB">İkinci oyuncu nesnesi</param>
    /// <returns>İlk oyuncu puanı ikinci oyuncu puanından düşük ise true döner</returns>
    public static bool operator <(Player playerA, Player playerB) => playerA._point < playerB._point;

    /// <summary>
    /// İki oyuncunun puan bazından eşitliğini döndürür
    /// </summary>
    /// <param name="playerA">İlk oyuncu nesnesi</param>
    /// <param name="playerB">İkinci oyuncu nesnesi</param>
    /// <returns>İlk oyuncu puanı ikinci oyuncu puanı ile denk ise true döner</returns>
    public static bool operator ==(Player playerA, Player playerB) => playerA._point == playerB._point;

    /// <summary>
    /// İki oyuncunun puan bazından eşitliğini döndürür
    /// </summary>
    /// <param name="playerA">İlk oyuncu nesnesi</param>
    /// <param name="playerB">İkinci oyuncu nesnesi</param>
    /// <returns>İlk oyuncu puanı ikinci oyuncu puanı ile denk değilse true döner</returns>
    public static bool operator !=(Player playerA, Player playerB) => playerA._point != playerB._point;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    public override bool Equals(object? player)
    {
        if (player == null)
            return false;
        if (player.GetType() != GetType())
            return false;

        var p = (Player)player;

        return _point == p._point;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }
}

/// <summary>
/// RGB renk bilgisi tutan nesne
/// </summary>
public class Color
{
    /// <summary>
    /// 0..255 arasında kırmızı renk kodu
    /// </summary>
    public byte Red { get; }
    /// <summary>
    /// 0..255 arasında yeşil renk kodu
    /// </summary>
    public byte Green { get; }
    /// <summary>
    /// 0..255 arasında mavi renk kodu
    /// </summary>
    public byte Blue { get; }
    /// <summary>
    /// 0.0 ile 1.0 arasında transparanlık değeri
    /// </summary>
    public double Alpha { get; }
    public Color(byte red, byte green, byte blue, double alpha)
    {
        //NOT: Alpha için 0.0 - 1.0 arasında olma hali kontrolü göz ardı edilmiştir.
        Red = red;
        Green = green;
        Blue = blue;
        Alpha = alpha;
    }
    /// <summary>
    /// Renkleri birleştirerek yeni bir rengin oluşturulmasını sağlar
    /// </summary>
    /// <param name="color1">Birinci renk</param>
    /// <param name="color2">İkinci renk</param>
    /// <returns></returns>
    public static Color operator +(Color color1, Color color2)
    {
        //NOT: Yeni bir renk elde edilirken 256'dan büyük olan toplamlar için yine 0-256 arası bir değer elde edilemsi işlemi göz ardı edilmiştir
        return new Color(
            (byte)(color1.Red + color2.Red)
            , (byte)(color1.Green + color2.Green)
            , (byte)(color1.Blue + color2.Blue)
            , color1.Alpha + color2.Alpha
        );
    }

    public override string ToString()
    {
        return $"{Red}:{Green}:{Blue} ({Alpha}%)";
    }
}