using Domain;

var world = new World();

Console.WriteLine("Games in Action Category\n");
var games_in_action_category = world.GetByGenre(Genre.Action);
ListGames(games_in_action_category);

Console.WriteLine("\nGames in AI Expertise\n");
var games_with_ai_expertise = world.GetGamesBySpecificExpertise(Expertise.AI);
ListGames(games_with_ai_expertise);

var oldest_game = world.GetOldestGame();
Console.WriteLine($"Oldest game is '{oldest_game.Title}'");

Console.WriteLine("\nGame Titles\n");
var game_titles = world.GetGameTitles();
foreach (var title in game_titles)
{
    Console.WriteLine(title);
}

Console.WriteLine("\nGames Ordered by Release Year");
var ordered_by_release_year = world.OrderByReleaseYear(Order.Descending);
ListGames(ordered_by_release_year);

Console.WriteLine("\nMulti Skills Programmers");
var programmers_by_multi_skills = world.FindProgrammersByMultiSkills();
foreach (var programmer in programmers_by_multi_skills)
{
    Console.WriteLine(programmer);
}

static void ListGames(List<VideoGame> games)
{
    foreach (var game in games)
    {
        Console.WriteLine($"{game.Title},{game.ReleaseYear},{game.Genre}");
        foreach (var programmer in game.Programmers)
        {
            Console.WriteLine($"\t{programmer.Name} ({programmer.Expertise})");
        }
    }
}