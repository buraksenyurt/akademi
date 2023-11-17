namespace Words;

class Program
{
    static void Main(string[] args)
    {
        WordManager manager = new WordManager();
        Console.WriteLine(manager.GetWord().ToString());
    }
}
