using Kanban.Entity;

namespace Kanban.Extensions;

public static class Int32Extensions
{
    public static WorkItemSize ConvertToWorkItemSize(this int value)
    {
        if (value > 0 && value <= 5)
        {
            return WorkItemSize.S;
        }
        else if (value > 5 && value <= 13)
        {
            return WorkItemSize.M;
        }
        else if (value > 13 && value <= 20)
        {
            return WorkItemSize.L;
        }
        else if (value > 20 && value <=80)
        {
            return WorkItemSize.XL;
        }
        else
        {
            return WorkItemSize.NA;
        }
    }
}
