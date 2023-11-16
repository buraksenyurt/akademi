namespace Kanban.Data.Tests;

// Bu birim test sınıfı TaskManager sınıfının metotlarına ait testleri içerir
public class TaskManagerTests
{
    [Fact]
    public void Change_Task_State_Works_Test()
    {
        var task = new Entity.Task
        {
            Title = "Ara sınav için hazırlık yap",
            Duration = 3,
            DurationType = Entity.Duration.Hour,
            TaskSize = Entity.TaskSize.M,
        };
        var expected = Entity.TaskState.Todo;
        Assert.Equal(task.State, expected);
        task.ChangeState();
        expected = Entity.TaskState.InProgress;
        Assert.Equal(task.State, expected);
    }

    // Fact niteliği(attribute) ile işaretlenmiş metotlar test metotlarıdır.
    // Runtime için ayrı bir anlam ifade ederler.
    // Belli kabul kriterlerinin doğruluğunu onaylamak için kullanılırlar
    [Fact]
    public void Create_TaskManager_Returns_Filled_Task_List_Test()
    {
        TaskManager taskManager = new TaskManager();
        taskManager.Add(new Entity.Task
        {
            Title = "Ara sınav için hazırlık yap",
            Duration = 3,
            DurationType = Entity.Duration.Hour,
            TaskSize = Entity.TaskSize.M,
        });
        taskManager.Add(new Entity.Task
        {
            Title = "Odayı temizle.",
            Duration = 1,
            DurationType = Entity.Duration.Hour,
            TaskSize = Entity.TaskSize.S
        });
        var actual = taskManager.GetTaskCount(Entity.TaskState.Todo);
        var expected = 2;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Get_TaskManager_InProgress_State_List_Test()
    {
        TaskManager taskManager = new TaskManager();
        var task1 = new Entity.Task
        {
            Title = "Ara sınav için hazırlık yap",
            Duration = 3,
            DurationType = Entity.Duration.Hour,
            TaskSize = Entity.TaskSize.M,
        };
        task1.ChangeState();
        taskManager.Add(task1);

        taskManager.Add(new Entity.Task
        {
            Title = "Odayı temizle.",
            Duration = 1,
            DurationType = Entity.Duration.Hour,
            TaskSize = Entity.TaskSize.S
        });
        var actual = taskManager.GetTaskCount(Entity.TaskState.InProgress);
        var expected = 1;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Add_New_Task_Returns_Valid_Id_Test()
    {
        TaskManager taskManager = new TaskManager();
        var actual = taskManager.Add(new Entity.Task
        {
            Title = "Ara sınav için hazırlık yap",
            Duration = 3,
            DurationType = Entity.Duration.Hour,
            TaskSize = Entity.TaskSize.M
        });
        var expected = 36;
        Assert.Equal(actual.ToString().Length, expected);
    }

    [Fact(Skip = "Geçici olarak devre dışı")]
    public void Add_Existing_Task_Returns_Zero_Id_Test()
    {

    }
}