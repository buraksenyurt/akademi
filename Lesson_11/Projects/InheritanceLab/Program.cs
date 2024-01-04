using System.Data;

namespace InheritanceLab;

class Program
{
    static void Main(string[] args)
    {
        Warrior bran = new(5, 100, 25, new Weapon(WeaponType.Sword, 5));
        Mage tirinity = new(7, 150, 1);

        tirinity.Attack(bran);

        Console.WriteLine($"Mage, warrior'a saldırdı. Warrior'un şu anki sağlık durumu, {bran.Health}");

        tirinity.Mana = 10;
        tirinity.Attack(bran);
        Console.WriteLine($"Mage dolan mana gücü ile tekrar saldırdı. Warrior'un şimdiki sağlık durumu, {bran.Health}");

        bran.Attack(tirinity);
        Console.WriteLine($"Bran kılıcı ile büyücüye saldırdı. Büyücünün şimdiki sağlık durumu, {tirinity.Health}");

        var mordor = new GameSchene(80, 60);
        mordor.AddCharacter(tirinity, 3, 5);
        mordor.AddCharacter(bran, 6, 7);
        mordor.AddCharacter(new Healer(1, 75, 1), 0, 0);
        mordor.AddCharacter(new Villager(5, 10), 10, 10);
        mordor.AddCharacter(new Villager(5, 10), 11, 10);
        mordor.AddCharacter(new Villager(5, 10), 12, 10);

        // Bir Character nesnesini aşağıdaki gibi oluşturmanın program açısından bir anlamı yoktur.
        // Bundan dolayı Character sınıfı abstract sınıf olarak da tasarlanabilir
        var anonymous = new Character(10, 100);
    }
}

/*
    Oyun sahasını aşağıdaki sınıf ile tarifleyebilir.
    Oyun sahasınının iki boyutlu bir matris olduğunu düşünerek hareket edebilir.
*/
public class GameSchene
{
    // Oyun sahasındaki karakterlerin tutulduğu matris aslında iki boyutlu bir dizidir
    private readonly Character[,] map;

    public GameSchene(int width, int height)
    {
        map = new Character[width, height];
    }
    /*
        Bu metot parametre olarak Character sınıfı türünden örneklerle çalışır.
        Yani kendisinden türeyen nesnelere ait örnekleri taşıyabilirler.
    */
    public void AddCharacter(Character character, int x, int y)
    {
        map[x, y] = character;
    }
    public void Move(Character character, int x, int y)
    {
    }
    public void Draw()
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                var currentCharacter = map[i, j];
                // Karakteri ekrana çiz
            }
        }
    }
}

/*
    Character sınıfı kendisinde türeyenlerin ortaklaşa kullandığı bazı özellikler (AttackPower, Health) içerir.
    Defend ve Attack fonksiyonları herkes için varsayılan bir çalışma şekline sahiptir.
    Ancak Attack metodu virtual tanımlandığından istenirse alt sınıflarda(türeyen sınıflarda) yeniden yazılabilir.
*/
public class Character
{
    public int AttackPower { get; set; }
    public int Health { get; set; }
    // Aşağıdaki yapıcı metodu(constructor) yazıncan varsayılan constructor(default olan, parametresiz olan versiyonu)
    // devre dışı kalmaktadır.
    public Character(int power, int health)
    {
        AttackPower = power;
        Health = health;
    }
    // public Character(){

    // }
    public void Defend(int damage)
    {
        Health -= damage;
    }
    /*
        Sanal metotlar varsayılan bir davranış icra ederler ama 
        istenirse bu davranış türeyen sınıfta fonksiyon override edilerek değiştirilebilir.
    */
    public virtual void Attack(Character target)
    {
        target.Health -= AttackPower;
    }
}

// Mage is a Charackter
public class Mage
    : Character // Mage sınıfının Character sınıfından türediğini gösterir
{
    public int Mana { get; set; }
    // base(power,health) ile aslında üst sınıfın yapıcı metodunu çağırıyor
    // ve Mage yapıcı metoduna gelen değerleri oraya gönderiyoruz
    public Mage(int power, int health, int mana)
        : base(power, health)
    {
        Mana = mana;
    }
    /*
        Attack metodu üst sınıfta virtual tanımlanldığından burada istenirse özelleştirilebilir
    */
    public override void Attack(Character target)
    {
        /*
            Örneğin büyücünün özel gücü belli bir değere gelmişse
            saldırı gücünü ikiye katlar ve mana değerini sıfırlar
        */
        if (Mana >= 7)
        {
            target.Health -= AttackPower * 2;
            Mana -= 7;
        }
        else
        {
            base.Attack(target); // bu üst sınıfın (türediğimiz yer) Attack metodunu çağırır
        }
    }
}

public class Warrior
    : Character
{
    public int Armor { get; set; }
    public Weapon EquipedWeapon { get; set; }
    public Warrior(int power, int health, int armor, Weapon weapon)
        : base(power, health)
    {
        Armor = armor;
        EquipedWeapon = weapon;
    }
    // Armor değeri sıfıra inene kadar health değerinin Defend fonksiyon sebebiyle azalmamasını nasıl sağlarız?
    public override void Attack(Character target)
    {
        int totalDamage = AttackPower;
        if (EquipedWeapon != null)
        {
            totalDamage += EquipedWeapon.AdditionalDamage;
        }
        target.Health -= totalDamage;
    }
}

/*
    Villager sınıfı da aslında bir Character nesnesidir. 
    Ancak üst sınıfta virtual olarak tanımlanmış Attack metodu ezmemiştir.
    Nitekim virtual üyeler alt türler ezilmek zorunda değildir.
*/
public class Villager
    : Character
{
    public Villager(int power, int health)
    : base(power, health)
    {
    }
}

public enum WeaponType
{
    Sword,
    Pistol,
    Knife
}

public class Weapon
{
    public WeaponType WeaponType { get; set; }
    public int AdditionalDamage { get; set; }
    public Weapon(WeaponType kind, int additionalDamage)
    {
        WeaponType = kind;
        AdditionalDamage = additionalDamage;
    }
}

/*
    İyileşebilir karakterler için aşağıdaki gibi bir arayüz tanımı olduğunu düşünelim.
*/
public interface IHealable
{
    void Heal(int amount);
}

/*
    Aşağıdaki tanıma göre, Healer aslında bir büyücüdür(Mage'den türediği için), ayrıca Mage
    Character sınıfından türediği Healer bir oyun karakteridir ve ayrıca iyileşebilir özellikler taşır
    çünkü IHealable arayüzünü uygulamaktadır.
*/
public class Healer
    : Mage, IHealable
{
    public Healer(int power, int health, int mana)
        : base(power, health, mana)
    {
    }

    public void Heal(int amount)
    {
        Health += amount;
    }
}