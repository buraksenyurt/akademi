namespace GameLib;

/*
    Aşağıdaki tanıma göre, Healer aslında bir büyücüdür(Mage'den türediği için), ayrıca Mage
    Character sınıfından türediği Healer bir oyun karakteridir ve ayrıca iyileşebilir özellikler taşır
    çünkü IHealable arayüzünü uygulamaktadır.
*/
public class Healer
    : Mage, IHealable
{
    public Healer(int power, int health, int mana, string name)
        : base(power, health, mana, name)
    {
    }

    public void Heal(Character target, int amount)
    {
        target.Health += amount;
    }

    // public override void Draw()
    // {
    //     base.Draw();
    // }
}