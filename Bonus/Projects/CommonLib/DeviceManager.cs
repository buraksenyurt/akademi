namespace CommonLib;

public class DeviceManager
{
    public Window CreateSplashScreen()
    {
        return new Window(640, 480, "Startup Screen");
    }

    public bool DrawScreen(Window window)
    {
        Console.WriteLine($"{window.Title} is drawing");
        return true;
    }
}

public interface IEntity
{
    string Title { get; set; }
    void Draw();
}

public class Window
    : IEntity
{
    public int Width { get; set; }
    public int Height { get; set; }
    public string Title { get; set; }
    public Window(int w, int h, string title)
    {
        Width = w;
        Height = h;
        Title = title;
    }

    public void Draw()
    {
        Console.WriteLine("Drawing");
    }
}
