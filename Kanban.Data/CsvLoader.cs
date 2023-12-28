using Kanban.Contract;
using Kanban.Entity;

namespace Kanban;

/*
    CsvLoader varsayılan olarak Task'ları bir dosyadan okuma görevini işler.
    Bu CSV uzantılı bir dosyadır.
    CsvLoader sınıfı ITaskLoader interface'inden türediği için bu arayüz tipinde belirtilen tüm metotları uygulamak zorundadır.
*/
public class CsvLoader
    : ITaskLoader
{
    public IEnumerable<Entity.Task> GetTasks()
    {
        var tasks = new List<Entity.Task>();
        try
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, "TaskData.csv");
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var columns = line.Split('|');
                Entity.Task newTask = new(Guid.Parse(columns[0]))
                {
                    Title = columns[1],
                    TaskSize = (TaskSize)Enum.Parse(typeof(TaskSize), columns[2]),
                    Duration = Convert.ToByte(columns[3]),
                    DurationType = Enum.Parse<DurationType>(columns[4]),
                    State = Enum.Parse<TaskState>(columns[5])
                };
                tasks.Add(newTask);
            }
        }
        catch (Exception excp)
        {

        }
        return tasks;
    }
}