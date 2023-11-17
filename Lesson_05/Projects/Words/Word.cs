namespace Words;

public class Word
{
    public string? Name { get; set; }
    public string? Content { get; set; }
    public override string ToString()
    {
        return $"{Name};{Content}";
    }
}