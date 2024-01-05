namespace GameLib;

/*
    Villager sınıfı da aslında bir Character nesnesidir. 
    Ancak üst sınıfta virtual olarak tanımlanmış Attack metodu ezmemiştir.
    Nitekim virtual üyeler alt türler ezilmek zorunda değildir.
*/
public class Villager
    : Character
{
    public Villager(int power, int health, string name)
        : base(power, health, name)
    {
    }
    public override void Draw()
    {
        Console.WriteLine($"{Name} ekrana çizilir");
    }
}