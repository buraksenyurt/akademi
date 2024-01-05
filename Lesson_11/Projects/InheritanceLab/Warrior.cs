namespace GameLib;

public class Warrior
    : Character
{
    public int Armor { get; set; }
    public Weapon EquipedWeapon { get; set; }
    public Warrior(int power, int health, int armor, string name, Weapon weapon)
        : base(power, health, name)
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
    public override void Draw()
    {
        Console.WriteLine($"{Name} ekrana çizilir");
    }
}