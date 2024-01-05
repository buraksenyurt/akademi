namespace GameLib;

/*
    İyileşebilir karakterler için aşağıdaki gibi bir arayüz tanımı olduğunu düşünelim.
*/
public interface IHealable
{
    void Heal(Character target, int amount);
}