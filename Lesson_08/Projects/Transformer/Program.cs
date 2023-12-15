using System.Text;

namespace Transformer;

class Program
{
    static void Main(string[] args)
    {
        var argsCheck = Converter.CheckArguments(args);
        if (argsCheck.IsError)
        {
            Console.WriteLine(argsCheck.Message);
            return;
        }
        var targetFormat = Enum.Parse(typeof(TargetFormat), args[2]);
        switch (targetFormat)
        {
            case TargetFormat.Base64Encoded:
                Converter.ApplyForBase64(args);
                break;
            case TargetFormat.OnlyBytes:
            case TargetFormat.Zipped:
                Console.WriteLine(Messages.NotImplementedYet);
                break;
            default:
                break;
        }

    }
}

public class Converter
{
    public static Response CheckArguments(string[] args)
    {
        if (args.Length != 3)
        {
            return new Response { IsError = true, Message = Messages.InvalidArgument };
        }
        if (!Enum.IsDefined(typeof(TargetFormat), args[2]))
        {
            return new Response { IsError = true, Message = Messages.InvalidTargetFormat };
        }
        if (!File.Exists(args[0]))
        {
            return new Response { IsError = true, Message = Messages.SourceFileDoesNotExist };
        }
        return new Response();
    }
    // TODO@buraksenyurt İleri seviye C# eğitiminde farklı formata dönüştürme işleri Dependecy Injection ile Loosely Coupled hale getirilir.
    public static void ApplyForBase64(string[] args)
    {
        using FileStream fileStream = new(args[0], FileMode.Open, FileAccess.Read);
        using StreamReader streamReader = new(fileStream);
        using FileStream fileStream1 = new(args[1], FileMode.Create, FileAccess.Write);
        using StreamWriter streamWriter = new(fileStream1);

        var line = streamReader.ReadLine();
        while (line != null)
        {
            var bytes = Encoding.ASCII.GetBytes(line);
            foreach (var b in bytes)
            {
                streamWriter.Write(b);
            }
            streamWriter.WriteLine();
            line = streamReader.ReadLine();
        }
    }
}

public static class Messages
{
    public const string InvalidArgument = "Arguments is invalid";
    public const string InvalidTargetFormat = "Target format is invalid";
    public const string SourceFileDoesNotExist = "Source file does not exist";
    public const string EverythingIsOk = "Everything is ok.";
    public const string NotImplementedYet = "Does not implement yet!";
}

public class Response
    : IEquatable<Response>
{
    public bool IsError { get; set; } = false;
    public string Message { get; set; } = Messages.EverythingIsOk;

    public bool Equals(Response? other)
    {
        if (other == null)
            return false;

        return IsError == other.IsError && Message == other.Message;
    }
}

public enum TargetFormat
{
    OnlyBytes,
    Base64Encoded,
    Zipped
}