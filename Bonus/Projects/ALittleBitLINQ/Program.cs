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

static void ListGames(List<VideoGame> games)
{
    foreach (var game in games)
    {
        Console.WriteLine($"{game.Title},{game.ReleaseYear}");
    }
}