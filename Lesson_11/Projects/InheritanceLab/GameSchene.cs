namespace GameLib;

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
                // Tüm karakterler abstract draw metodunu zaten uygulamak zorundalar.
                currentCharacter?.Draw();
            }
        }
    }
}