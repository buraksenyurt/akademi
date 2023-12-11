using Kanban.Entity;

namespace Kanban.Extensions;

public static class Int32Extensions
{
    public static TaskSize ConvertToTaskSize(this int value)
    {
        if (value > 0 && value <= 5)
        {
            return TaskSize.S;
        }
        else if (value > 5 && value <= 13)
        {
            return TaskSize.M;
        }
        else if (value > 13 && value <= 20)
        {
            return TaskSize.L;
        }
        else if (value > 20 && value <=80)
        {
            return TaskSize.XL;
        }
        else
        {
            return TaskSize.NA;
        }
    }
}
