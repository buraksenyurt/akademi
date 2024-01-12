namespace UseArguments;

/*
    Bu örnekte programa komut satırından gelen argümanları okumak için davranışsal tasarım kalıplarından olan
    Command tasarım deseninin basit bir kullanımı örneklenmektedir.

    Komut satırından girilecek olan -add -list -get gibi komutlar birer Command nesnesi olarak düşünülür.
    Bu komutların parametreleri olabilir. 

    Her komutun normal şartlarda işletmesi gereken bir takım süreçler vardır.

    Örneğin -add komutunu verdiğinizde belki de bir listeye yeni öğe bilgilerinin eklenmesi işi icra edilecektir.
    ya da -list komutu ile veri kümesinin parametredeki değerlere göre sıralanarak listelenmesi işlemi icra edilecektir.

    Bu nedenle her Command nesnesinin belli işlevsellikleri uygulaması gerekir. Bu ICommand gibi bir arayüz üzerinde tanımlanır.

    Programa gelen komut satırı argümanları ayrıca CommandParser gibi bir nesne ile parse edilir ve uygun Command nesne örneklerine
    yönlendirme işlemleri gerçekleştirilir.
*/

class Program
{
    static void Main(string[] args)
    {
        var cmdParser = new CommandParser();
        var cmd = cmdParser.Parse(args);
        cmd.Execute(args);
    }
}

public interface ICommand
{
    void Execute(params string[] args);
}

public class AddCommand
    : ICommand
{
    public void Execute(params string[] args)
    {
        string title = args[1];
        int size = int.Parse(args[2]);
        bool isActive = bool.Parse(args[3]);
        Console.WriteLine($"Girilen komut bilgisi -add. Parametreleri {title} {size} {isActive}");
    }
}

public class ListCommand
    : ICommand
{
    public void Execute(params string[] args)
    {
        string query = args[1];
        Console.WriteLine($"Girilen komut bilgisi -list. Parametresi {query}");
    }
}

public class UnkownCommand
    : ICommand
{
    public void Execute(params string[] args)
    {
    }
}

public class CommandParser
{
    public ICommand Parse(string[] args)
    {
        if (args.Length == 0)
            return new UnkownCommand();

        switch (args[0])
        {
            case "-add":
                return new AddCommand();
            case "-list":
                return new ListCommand();
            default:
                return new UnkownCommand();
        }
    }
}
