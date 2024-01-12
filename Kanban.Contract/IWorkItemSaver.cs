using Kanban.Entity;

namespace Kanban.Contract;
public interface IWorkItemSaver
{
    SaveResponse Save(IEnumerable<WorkItem> workItems);
}