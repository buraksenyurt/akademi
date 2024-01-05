namespace GameLib;

// Mage is a Charackter
public class Mage
    : Character // Mage sınıfının Character sınıfından türediğini gösterir
{
    public int Mana { get; set; }
    // base(power,health) ile aslında üst sınıfın yapıcı metodunu çağırıyor
    // ve Mage yapıcı metoduna gelen değerleri oraya gönderiyoruz
    public Mage(int power, int health, int mana, string name)
        : base(power, health, name)
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
    public override void Draw()
    {
        Console.WriteLine($"{Name} ekrana çizilir");
    }
}