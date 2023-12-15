namespace Transformer;

class Program
{
    static void Main(string[] args)
    {
    }

}

public class Converter
{
    public Response CheckArguments(string[] args)
    {
        if (args.Length != 3)
        {
            return new Response { IsError = true, Message = ResponseMessages.InvalidArgument };
        }
        if (!Enum.IsDefined(typeof(TargetFormat), args[2]))
        {
            return new Response { IsError = true, Message = ResponseMessages.InvalidTargetFormat };
        }
        if (!File.Exists(args[0]))
        {
            return new Response { IsError = true, Message = ResponseMessages.SourceFileDoesNotExist };
        }
        return new Response();
    }
}

public static class ResponseMessages
{
    public const string InvalidArgument = "Arguments is invalid";
    public const string InvalidTargetFormat = "Target format is invalid";
    public const string SourceFileDoesNotExist = "Source file does not exist";
    public const string EverythingIsOk = "Everything is ok.";
}

public class Response
{
    public bool IsError { get; set; } = false;
    public string Message { get; set; } = ResponseMessages.EverythingIsOk;
}

public enum TargetFormat
{
    OnlyBytes,
    Base64Encoded,
    Zipped
}