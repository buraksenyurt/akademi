namespace Playground3;

internal class Program
{
    static void Main()
    {
        var johnDoe = new Customer
        {
            FirstName = "Jhone",
            MiddleName = "Junior",
            LastName = "Doe"
        };
        Console.WriteLine(johnDoe.ToString("FL", null));
        Console.WriteLine(johnDoe.ToString("LF", null));
        Console.WriteLine(johnDoe.ToString("F", null));
        Console.WriteLine(johnDoe.ToString("L", null));
    }
}

class Customer
    : IFormattable
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; } = string.Empty;
    public string LastName { get; set; }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        _ = formatProvider ?? System.Globalization.CultureInfo.CurrentCulture;

        return format switch
        {
            "FL" => $"{FirstName} {MiddleName}, {LastName}",
            "LF" => $"{LastName},{FirstName} {MiddleName}",
            "F" => $"{FirstName} {MiddleName}",
            "L" => $"{LastName}",
            _ => throw new ArgumentException("This format is not provided"),
        };
    }
}
