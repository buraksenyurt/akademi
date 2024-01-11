
namespace Domain;

/// <summary>
/// Oyun veri tabanı
/// </summary>
public class World
{
    private readonly List<VideoGame> games;
    public World()
    {
        games = new List<VideoGame>
        {
            new() { Title = "Space Adventure", Genre = Genre.Action, ReleaseYear = 2021, Programmers = new List<Programmer> { new() { Name = "Alice Johnson", Expertise = Expertise.Graphics }, new() { Name = "Bob Smith", Expertise = Expertise.AI } } },
            new() { Title = "Mystery Island", Genre = Genre.Adventure, ReleaseYear = 2020, Programmers = new List<Programmer> { new() { Name = "Charlie Brown", Expertise = Expertise.Gameplay }, new() { Name = "Alice Johnson", Expertise = Expertise.Graphics } } },
            new() { Title = "Lost in Time", Genre = Genre.Puzzle, ReleaseYear = 2019, Programmers = new List<Programmer> { new() { Name = "David Lee", Expertise = Expertise.LevelDesign } } },
            new() { Title = "Speed Racer", Genre = Genre.Racing, ReleaseYear = 2022, Programmers = new List<Programmer> { new() { Name = "Eva Green", Expertise = Expertise.Physics }, new() { Name = "Frank Moore", Expertise = Expertise.AI } } },
            new() { Title = "Sky High", Genre = Genre.Simulation, ReleaseYear = 2018, Programmers = new List<Programmer> { new() { Name = "Gina White", Expertise = Expertise.Graphics } } },
            new() { Title = "Battle Grounds", Genre = Genre.Strategy, ReleaseYear = 2017, Programmers = new List<Programmer> { new() { Name = "Henry Ford", Expertise = Expertise.AI }, new() { Name = "Irene Paul", Expertise = Expertise.Gameplay } } },
            new() { Title = "Cyber Quest", Genre = Genre.SciFi, ReleaseYear = 2021, Programmers = new List<Programmer> { new() { Name = "Jack Hill", Expertise = Expertise.LevelDesign } } },
            new() { Title = "Fantasy World", Genre = Genre.RPG, ReleaseYear = 2019, Programmers = new List<Programmer> { new() { Name = "Kathy Long", Expertise = Expertise.Story } } },
            new() { Title = "Ocean Explorer", Genre = Genre.Adventure, ReleaseYear = 2020, Programmers = new List<Programmer> { new() { Name = "Liam Neeson", Expertise = Expertise.Graphics } } },
            new() { Title = "Zombie Attack", Genre = Genre.Horror, ReleaseYear = 2018, Programmers = new List<Programmer> { new() { Name = "Mona Lisa", Expertise = Expertise.AI } } },
            new() { Title = "Robot Wars", Genre = Genre.Action, ReleaseYear = 2022, Programmers = new List<Programmer> { new() { Name = "Nathan Drake", Expertise = Expertise.Gameplay }, new() { Name = "Olivia Wilde", Expertise = Expertise.LevelDesign } } },
            new() { Title = "Pirate's Treasure", Genre = Genre.Adventure, ReleaseYear = 2017, Programmers = new List<Programmer> { new() { Name = "Peter Pan", Expertise = Expertise.Story } } },
            new() { Title = "Dungeon Crawler", Genre = Genre.RPG, ReleaseYear = 2021, Programmers = new List<Programmer> { new() { Name = "Quincy Adams", Expertise = Expertise.AI } } },
            new() { Title = "Alien Invasion", Genre = Genre.SciFi, ReleaseYear = 2019, Programmers = new List<Programmer> { new() { Name = "Rachel Green", Expertise = Expertise.Graphics } } },
            new() { Title = "Mystic Quest", Genre = Genre.Fantasy, ReleaseYear = 2020, Programmers = new List<Programmer> { new() { Name = "Steve Jobs", Expertise = Expertise.Gameplay } } },
            new() { Title = "Racer X", Genre = Genre.Racing, ReleaseYear = 2018, Programmers = new List<Programmer> { new() { Name = "Tony Stark", Expertise = Expertise.Physics } } },
            new() { Title = "Galactic Odyssey", Genre = Genre.SciFi, ReleaseYear = 2022, Programmers = new List<Programmer> { new() { Name = "Uma Thurman", Expertise = Expertise.Story }, new() { Name = "Victor Hugo", Expertise = Expertise.LevelDesign } } },
            new() { Title = "Jungle Journey", Genre = Genre.Adventure, ReleaseYear = 2021, Programmers = new List<Programmer> { new() { Name = "Walter White", Expertise = Expertise.Graphics } } },
            new() { Title = "Knight's Legacy", Genre = Genre.RPG, ReleaseYear = 2020, Programmers = new List<Programmer> { new() { Name = "Xena Warrior", Expertise = Expertise.AI } } },
            new() { Title = "Lunar Escape", Genre = Genre.Puzzle, ReleaseYear = 2019, Programmers = new List<Programmer> { new() { Name = "Yvonne Blake", Expertise = Expertise.LevelDesign } } },
            new() { Title = "Ninja Assault", Genre = Genre.Action, ReleaseYear = 2018, Programmers = new List<Programmer> { new() { Name = "Zachary Levi", Expertise = Expertise.Gameplay } } }
        };
    }

    /// <summary>
    /// Türe göre oyunların listesini döndürür
    /// </summary>
    /// <param name="genre">Oyun türü</param>
    /// <returns>Oyun Listesi</returns>
    public List<VideoGame> GetByGenre(Genre genre)
    {
        return games.Where(g => g.Genre == genre).ToList();
    }
    /// <summary>
    /// Oyun listesini sıralama yönüne göre verir
    /// </summary>
    /// <param name="ordering">Sıralama yönü. Ascending veya Descending</param>
    /// <returns>Oyun Listesi</returns>
    public List<VideoGame> OrderByReleaseYear(Order ordering)
    {
        if (ordering == Order.Descending)
            return games.OrderByDescending(g => g.ReleaseYear).ToList();

        return games.OrderBy(g => g.ReleaseYear).ToList();
    }

    /// <summary>
    /// Oyun adlarını döndürür
    /// </summary>
    /// <returns>Oyun adları listesi</returns>
    public List<string> GetGameTitles()
    {
        return games.Select(g => g.Title).ToList();
    }

    /// <summary>
    /// Bir programcının dahil olduğu oyunların listesini döndürür
    /// </summary>
    /// <param name="name">Programcının adı</param>
    /// <returns>Oyun listesi</returns>
    public List<VideoGame> GetGamesByProgrammer(string name)
    {
        return games.Where(g => g.Programmers.Any(p => p.Name == name)).ToList();
    }

    /// <summary>
    /// Belli bir yıldan sonraki oyunların listesini verir
    /// </summary>
    /// <param name="year">Sürüm yılı</param>
    /// <returns>Oyun Listesi</returns>
    public List<VideoGame> GetGamesAfterReleaseYear(int year)
    {
        return games.Where(g => g.ReleaseYear > year).ToList();
    }

    /// <summary>
    /// Oyunları türüne göre gruplayarak döndürür
    /// </summary>
    /// <returns>Kayıt listesi</returns>
    public List<GroupedGame> CountingGameByGenre()
    {
        return games.GroupBy(g => g.Genre).Select(grp => new GroupedGame { Genre = grp.Key, Count = grp.Count() }).ToList();
    }

    /// <summary>
    /// Birden fazla yeteneği olan programcıların adlarını döndürür
    /// </summary>
    /// <returns>Programcı adları</returns>
    public List<string> FindProgrammersByMultiSkills()
    {
        return games.SelectMany(g => g.Programmers).GroupBy(p => p.Name).Where(group => group.Count() > 1).Select(group => group.Key).ToList();
    }

    /// <summary>
    /// Oyun ve programcılarına ait listeyi döndürür
    /// </summary>
    /// <returns>Oyun ve programcılar listesi</returns>
    public List<GameAndProgrammers> GetGamesAndProgrammers()
    {
        return games.Select(g => new GameAndProgrammers(g.Title, g.Programmers.Select(p => p.Name))).ToList();
    }

    /// <summary>
    /// Veri setindeki en eski oyun bilgisini döndürür
    /// </summary>
    /// <returns>Oyun bilgisi</returns>
    public VideoGame? GetOldestGame()
    {
        return games.OrderByDescending(g => g.ReleaseYear).LastOrDefault();
    }

    /// <summary>
    /// Uzmanlık bilgisine göre oyun listesini döndürür
    /// </summary>
    /// <param name="expertise">Uzmanlık bilgisi</param>
    /// <returns>Oyun Listesi</returns>
    public List<VideoGame> GetGamesBySpecificExpertise(Expertise expertise)
    {
        return games.Where(g => g.Programmers.Any(p => p.Expertise == expertise)).ToList();
    }
}

public record GroupedGame
{
    public Genre Genre { get; set; }
    public int Count { get; set; }
}

public enum Order
{
    Ascending,
    Descending
}

public record GameAndProgrammers(string Title, IEnumerable<string> Programmers);
