namespace GameLib;

/*
    Character sınıfı kendisinde türeyenlerin ortaklaşa kullandığı bazı özellikler (AttackPower, Health) içerir.
    Defend ve Attack fonksiyonları herkes için varsayılan bir çalışma şekline sahiptir.
    Ancak Attack metodu virtual tanımlandığından istenirse alt sınıflarda(türeyen sınıflarda) yeniden yazılabilir.
*/
public abstract class Character
{
    public string Name { get; set; }
    public int AttackPower { get; set; }
    public int Health { get; set; }
    // Aşağıdaki yapıcı metodu(constructor) yazıncan varsayılan constructor(default olan, parametresiz olan versiyonu)
    // devre dışı kalmaktadır.
    public Character(int power, int health, string name)
    {
        AttackPower = power;
        Health = health;
        Name = name;
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

    /*
        abstract sınıflar içinde tanımlanan abstract üyeler(metotlar, özellikler vs)
        türeyen sınıflarda mutlaka ezilmek (override) zorundadır.
        abstract üyeler diğer metotlar gibi iş yapan gövdelere sahip değildir.
    */

    public abstract void Draw();
}