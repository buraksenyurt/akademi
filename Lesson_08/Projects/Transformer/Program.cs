namespace Transformer;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
    static bool CheckArguments(string[] args){
        return false;
    }
}

enum TargetFormat{
    OnlyBytes,
    Base64Encoded
}