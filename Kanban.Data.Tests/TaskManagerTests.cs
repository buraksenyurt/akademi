using Kanban.Entity;

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
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.M,
        };
        var expected = TaskState.Todo;
        Assert.Equal(task.State, expected);
        task.ChangeState();
        expected = TaskState.InProgress;
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
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.M,
        });
        taskManager.Add(new Entity.Task
        {
            Title = "Odayı temizle.",
            Duration = 1,
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.S
        });
        var actual = taskManager.GetTaskCount(TaskState.Todo);
        var expected = 2;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Get_TaskManager_InProgress_State_Count_Test()
    {
        TaskManager taskManager = new();
        var task1 = new Entity.Task
        {
            Title = "Ara sınav için hazırlık yap",
            Duration = 3,
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.M,
        };
        task1.ChangeState();
        taskManager.Add(task1);

        taskManager.Add(new Entity.Task
        {
            Title = "Odayı temizle.",
            Duration = 1,
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.S
        });
        var actual = taskManager.GetTaskCount(TaskState.InProgress);
        var expected = 1;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Initiated_Task_In_Todo_State_Test()
    {
        var task1 = new Entity.Task
        {
            Title = "Ara sınav için hazırlık yap",
            Duration = 3,
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.M,
        };
        var expected = TaskState.Todo;
        Assert.Equal(task1.State, expected);
    }

    [Fact]
    public void Get_TaskManager_InProgress_State_List_Test()
    {
        TaskManager taskManager = new TaskManager();
        taskManager.Add(new Entity.Task
        {
            Title = "Odayı temizle.",
            Duration = 1,
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.S
        });
        var task1 = new Entity.Task
        {
            Title = "Ara sınav için hazırlık yap",
            Duration = 3,
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.M,
        };
        task1.ChangeState();
        taskManager.Add(task1);
        var actual = taskManager.GetTasks(TaskState.InProgress);
        var expected = task1;
        Assert.True(actual.Count == 1);
        Assert.Equal(expected, actual[0]);
    }

    [Fact]
    public void Add_New_Task_Returns_Valid_Id_Test()
    {
        TaskManager taskManager = new TaskManager();
        var actual = taskManager.Add(new Entity.Task
        {
            Title = "Ara sınav için hazırlık yap",
            Duration = 3,
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.M
        });
        var expected = 36;
        Assert.Equal(actual.ToString().Length, expected);
    }

    [Fact]
    public void Get_Task_Test()
    {
        TaskManager taskManager = new TaskManager();
        taskManager.Add(new Entity.Task
        {
            Title = "Odayı temizle.",
            Duration = 1,
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.S
        });
        var task1 = new Entity.Task
        {
            Title = "Ara sınav için hazırlık yap",
            Duration = 3,
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.M,
        };
        taskManager.Add(task1);
        var expected = task1;
        var actual = taskManager.GetTask(task1.Id);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Get_Indefined_Task_Returns_Null_Test()
    {
        TaskManager taskManager = new TaskManager();
        taskManager.Add(new Entity.Task
        {
            Title = "Odayı temizle.",
            Duration = 1,
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.S
        });
        var task1 = new Entity.Task
        {
            Title = "Ara sınav için hazırlık yap",
            Duration = 3,
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.M,
        };
        taskManager.Add(task1);
        var actual = taskManager.GetTask(Guid.Empty);
        Assert.True(actual == null);
    }

    [Fact(Skip = "Geçici olarak devre dışı")]
    public void Add_Existing_Task_Returns_Zero_Id_Test()
    {
    }
}