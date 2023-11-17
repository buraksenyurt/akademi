namespace Words;
public class WordManager
{
    private Dictionary<int, Word> _database;
    private Random _rnd;
    public Word GetWord()
    {
        var index = _rnd.Next(1, _database.Count + 1);
        return _database[index];
    }
    public WordManager()
    {
        _database = new Dictionary<int, Word>();
        _rnd = new Random();
        Seed();
    }
    private void Seed()
    {
        _database.Add(
            1
            , new Word
            {
                Name = "Apple",
                Content = "Apple , Elma anlamına gelir ama aynı zamanda dünyanın önemli teknoloji devlerinden birisinin de ismidir"
            });
        _database.Add(
            2
            , new Word
            {
                Name = "Circle",
                Content = "Çember, halka anlamlarında kullanılır ama aynı zamanda P2P ödeme çözümleri sunan bir FinTech firmasının adıdır."
            });
        _database.Add(
            3
            , new Word
            {
                Name = "Private",
                Content = "Daha çok gizli anlamında kullanılır ama askeri terim olarak da er anlamına gelen bir sıfattır. Örneğin kurtarılan Er Ryan gibi."
            });
        _database.Add(
            4
            , new Word
            {
                Name = "Alone",
                Content = "Yalnızların kelimesidir ama 2005 yapımı meşhur bir oyunda da kullanılmıştır, Alone in the Dark."
            });
        _database.Add(
            5
            , new Word
            {
                Name = "Stardust",
                Content = "Yıldız tozu demektir. Ayrıca İngiliz yazar Neil Gaiman'ın 1999 yılında yazdığı fantastik eserin adıdır. "
            });
        _database.Add(
            6
            , new Word
            {
                Name = "Red",
                Content = "Kırmızı, al, kızıl. Ayrıca zamanın en iyi casus filmlerinden The Hunt for Red October'da da geçer."
            });
    }
}