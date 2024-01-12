using Kanban.Entity;

namespace Kanban.Extensions;
public static class StringExtensions
{
    public static WorkItemSize ToWorkItemSize(this string input)
    {
        return input.ToLower() switch
        {
            "s" or "small" => WorkItemSize.S,
            "m" or "medium" => WorkItemSize.M,
            "l" or "large" => WorkItemSize.L,
            "xl" or "xlarge" => WorkItemSize.XL,
            _ => WorkItemSize.NA,
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