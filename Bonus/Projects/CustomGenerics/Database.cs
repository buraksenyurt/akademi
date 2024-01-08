namespace Database;

public interface IEntity
{
    int Id { get; set; }
}

public class Announcment
    : IEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int Id { get; set; }
}