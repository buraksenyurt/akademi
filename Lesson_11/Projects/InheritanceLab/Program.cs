namespace InheritanceLab;

class Program
{
    static void Main(string[] args)
    {
        Warrior bran = new(5, 100, 25);
        Mage tirinity = new(7, 150, 1);

        tirinity.Attack(bran);

        Console.WriteLine($"{bran.Health}");

        tirinity.Mana = 10;
        tirinity.Attack(bran);
        Console.WriteLine($"{bran.Health}");
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
    public Warrior(int power, int health, int armor)
        : base(power, health)
    {
        Armor = armor;
    }
    // Armor değeri sıfıra inene kadar health değerinin Defend fonksiyon sebebiyle azalmamasını nasıl sağlarız?
    public override void Attack(Character target)
    {
        base.Attack(target);
    }
}