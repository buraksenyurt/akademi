using Kanban.Entity;

namespace Kanban.Extensions;
public static class StringExtensions
{
    public static TaskSize ToTaskSize(this string input)
    {
        return input.ToLower() switch
        {
            "s" or "small" => TaskSize.S,
            "m" or "medium" => TaskSize.M,
            "l" or "large" => TaskSize.L,
            "xl" or "xlarge" => TaskSize.XL,
            _ => TaskSize.NA,
        };
    }
    public static DurationType ToDurationType(this char input)
    {
        return input switch
        {
            'h' => DurationType.Hour,
            'd' => DurationType.Day,
            'w' => DurationType.Week,
            'm' => DurationType.Month,
            'y' => DurationType.Year,
            _ => DurationType.NA
        };
    }
}