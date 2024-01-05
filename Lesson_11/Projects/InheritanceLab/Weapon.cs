namespace GameLib;

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