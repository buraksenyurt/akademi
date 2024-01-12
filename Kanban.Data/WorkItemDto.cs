namespace Kanban.Data;
public class WorkItemDto {
    public string Id { get; set; }
    public string Title { get; set; }
    public short Duration { get; set; }
    public short DurationType { get; set; }
    public short WorkItemSize { get; set; }
    public short State { get; set; }
}