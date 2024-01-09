namespace Domain;

public class VideoGame
{
    public string Title { get; set; }
    public Genre Genre { get; set; }
    public int ReleaseYear { get; set; }
    public List<Programmer> Programmers { get; set; }
}