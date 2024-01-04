using Kanban.Contract;
using Kanban.Entity;
using Moq;

namespace Kanban.Data.Tests;

// Bu birim test sınıfı TaskManager sınıfının metotlarına ait testleri içerir
public class TaskManagerTests
{
    [Fact]
    public void Change_Task_State_Works_Test()
    {
        var task = new Entity.Task(null)
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
        /*
            Bu sefer GetTasks metodunun dönmesi istenen içeriğini bir Mock nesnesi ile sağlıyoruz.
            Önce Moq paketinden Mock<T> nesnesi örnekliyoruz.
            GetTasks metodu için bir Setup kurguluyoruz ve buradan dönmesi istenen nesneyi belirliyoruz(taskList).
            Son olarak ITaskLoader'a ihtiyaç duyan TaskManager sınıfının constructor metoduna mock nesnesini veriyoruz.
        */
        var taskLoaderMock = new Mock<ITaskLoader>();
        var tasks = new List<Entity.Task>{
                new(null)
                {
                    Title = "Ara sınav için hazırlık yap",
                    Duration = 3,
                    DurationType = DurationType.Hour,
                    TaskSize = TaskSize.M,
                },
                new(null)
                {
                    Title = "Odayı temizle.",
                    Duration = 1,
                    DurationType = DurationType.Hour,
                    TaskSize = TaskSize.S
                }
        };

        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Task listesi başarıyla yüklendi",
            LoadedObjectCount = tasks.Count,
            Tasks = tasks
        };
        taskLoaderMock.Setup(m => m.GetTasks()).Returns(response);
        //ITaskLoader taskLoader = new FakeTaskLoader();
        // TaskManager taskManager = new(taskLoader);
        TaskManager taskManager = new(taskLoaderMock.Object);
        var actual = taskManager.GetTaskCount(TaskState.Todo);
        var expected = 2;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Get_TaskManager_InProgress_State_Count_Test()
    {
        var taskLoaderMock = new Mock<ITaskLoader>();
        var tasks = new List<Entity.Task>{
                new(null)
                {
                    Title = "Ara sınav için hazırlık yap",
                    Duration = 3,
                    DurationType = DurationType.Hour,
                    TaskSize = TaskSize.M,
                },
                new(null)
                {
                    Title = "Odayı temizle.",
                    Duration = 1,
                    DurationType = DurationType.Hour,
                    TaskSize = TaskSize.S
                }
        };
        tasks[0].ChangeState();
        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Task listesi başarıyla yüklendi",
            LoadedObjectCount = tasks.Count,
            Tasks = tasks
        };
        taskLoaderMock.Setup(m => m.GetTasks()).Returns(response);

        //TaskManager taskManager = new(new FakeTaskLoaderWithState());
        TaskManager taskManager = new(taskLoaderMock.Object);
        var actual = taskManager.GetTaskCount(TaskState.InProgress);
        var expected = 1;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Initiated_Task_In_Todo_State_Test()
    {
        var task1 = new Entity.Task(null)
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
        var taskLoaderMock = new Mock<ITaskLoader>();
        var tasks = new List<Entity.Task>{
                new(null)
                {
                    Title = "Ara sınav için hazırlık yap",
                    Duration = 3,
                    DurationType = DurationType.Hour,
                    TaskSize = TaskSize.M,
                },
                new(null)
                {
                    Title = "Odayı temizle.",
                    Duration = 1,
                    DurationType = DurationType.Hour,
                    TaskSize = TaskSize.S
                }
        };
        tasks[0].ChangeState();
        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Task listesi başarıyla yüklendi",
            LoadedObjectCount = tasks.Count,
            Tasks = tasks
        };
        taskLoaderMock.Setup(m => m.GetTasks()).Returns(response);
        TaskManager taskManager = new(taskLoaderMock.Object);
        var actual = taskManager.GetTasks(TaskState.InProgress);
        Assert.True(actual.Count == 1);
    }

    [Fact]
    public void Add_New_Task_Returns_Valid_Id_Test()
    {
        var taskLoaderMock = new Mock<ITaskLoader>();
        var tasks = new List<Entity.Task>();
        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Task listesi başarıyla yüklendi",
            LoadedObjectCount = tasks.Count,
            Tasks = tasks
        };
        taskLoaderMock.Setup(m => m.GetTasks()).Returns(response);
        TaskManager taskManager = new(taskLoaderMock.Object);
        var actual = taskManager.Add(new Entity.Task(null)
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
        var taskLoaderMock = new Mock<ITaskLoader>();
        var tasks = new List<Entity.Task>();
        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Task listesi başarıyla yüklendi",
            LoadedObjectCount = tasks.Count,
            Tasks = tasks
        };
        taskLoaderMock.Setup(m => m.GetTasks()).Returns(response);
        TaskManager taskManager = new(taskLoaderMock.Object);
        var task1 = new Entity.Task(null)
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
    public void Get_Undefined_Task_Returns_Null_Test()
    {
        var taskLoaderMock = new Mock<ITaskLoader>();
        var tasks = new List<Entity.Task>();
        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Task listesi başarıyla yüklendi",
            LoadedObjectCount = tasks.Count,
            Tasks = tasks
        };
        taskLoaderMock.Setup(m => m.GetTasks()).Returns(response);
        TaskManager taskManager = new(taskLoaderMock.Object);

        var task1 = new Entity.Task(null)
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

    [Fact]
    public void Added_New_Task_Triggered_An_Event_If_Subscribed()
    {
        var taskLoaderMock = new Mock<ITaskLoader>();
        var tasks = new List<Entity.Task>();
        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Task listesi başarıyla yüklendi",
            LoadedObjectCount = tasks.Count,
            Tasks = tasks
        };
        taskLoaderMock.Setup(m => m.GetTasks()).Returns(response);
        TaskManager taskManager = new(taskLoaderMock.Object);

        var eventTriggered = false;
        taskManager.NewTaskAdded += (source, eventArgs) =>
        {
            eventTriggered = true;
        };
        var task1 = new Entity.Task(null)
        {
            Title = "Arkadaşlarına hediye etmek üzere okuduklarından 10 kitap ayır",
            Duration = 3,
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.S,
        };
        taskManager.Add(task1);
        var expected = true;
        Assert.Equal(expected, eventTriggered);
    }

    [Fact]
    public void Added_New_Task_Do_Not_Triggered_An_Event_If_Not_Exist()
    {
        var taskLoaderMock = new Mock<ITaskLoader>();
        var tasks = new List<Entity.Task>();
        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Task listesi başarıyla yüklendi",
            LoadedObjectCount = tasks.Count,
            Tasks = tasks
        };
        taskLoaderMock.Setup(m => m.GetTasks()).Returns(response);
        TaskManager taskManager = new(taskLoaderMock.Object);

        var eventTriggered = false;
        var task1 = new Entity.Task(null)
        {
            Title = "Arkadaşlarına hediye etmek üzere okuduklarından 10 kitap ayır",
            Duration = 3,
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.S,
        };
        taskManager.Add(task1);
        var expected = false;
        Assert.Equal(expected, eventTriggered);
    }


    [Fact(Skip = "Geçici olarak devre dışı")]
    public void Add_Existing_Task_Returns_Zero_Id_Test()
    {
    }

    [Fact]
    public void Save_All_Tasks_To_CSV_File_Return_Success_Test()
    {
        var taskLoaderMock = new Mock<ITaskLoader>();
        var tasks = new List<Entity.Task>();
        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Task listesi başarıyla yüklendi",
            LoadedObjectCount = tasks.Count,
            Tasks = tasks
        };
        taskLoaderMock.Setup(m => m.GetTasks()).Returns(response);
        TaskManager taskManager = new(taskLoaderMock.Object);

        taskManager.Add(new Entity.Task(null)
        {
            Title = "Odayı temizle.",
            Duration = 1,
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.S
        });
        var task1 = new Entity.Task(null)
        {
            Title = "Final sınavı için hazırlık yapmalısın",
            Duration = 6,
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.M,
        };
        taskManager.Add(task1);
        task1.ChangeState();
        var task2 = new Entity.Task(null)
        {
            Title = "Denizler Altında 20bin Fersah kitabının özeti çıkartılacak",
            Duration = 3,
            DurationType = DurationType.Month,
            TaskSize = TaskSize.XL,
        };
        taskManager.Add(task2);
        task2.ChangeState();
        task2.ChangeState();
        var actual = taskManager.Save(new FakeTaskSaver());
        var expected = true;
        Assert.Equal(expected, actual.IsSuccess);

        // Assert.True(actual);
        // Assert.True(taskManager.Save("Board"));
    }

    [Fact]
    public void Save_All_Tasks_To_CSV_File_Return_Fail_Test()
    {
        var taskLoaderMock = new Mock<ITaskLoader>();
        var tasks = new List<Entity.Task>();
        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Task listesi başarıyla yüklendi",
            LoadedObjectCount = tasks.Count,
            Tasks = tasks
        };
        taskLoaderMock.Setup(m => m.GetTasks()).Returns(response);
        TaskManager taskManager = new(taskLoaderMock.Object);

        taskManager.Add(new Entity.Task(null)
        {
            Title = "Odayı temizle.",
            Duration = 1,
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.S
        });
        var task1 = new Entity.Task(null)
        {
            Title = "Final sınavı için hazırlık yapmalısın",
            Duration = 6,
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.M,
        };
        taskManager.Add(task1);
        task1.ChangeState();
        var task2 = new Entity.Task(null)
        {
            Title = "Denizler Altında 20bin Fersah kitabının özeti çıkartılacak",
            Duration = 3,
            DurationType = DurationType.Month,
            TaskSize = TaskSize.XL,
        };
        taskManager.Add(task2);
        task2.ChangeState();
        task2.ChangeState();
        var actual = taskManager.Save(new FakeTaskSaverInFail());
        Assert.False(actual.IsSuccess);
        Assert.Equal(new FileNotFoundException().Message, actual.Exception == null ? "" : actual.Exception.Message);
    }

    [Fact]
    public void Load_Tasks_From_File_Test()
    {
        var taskLoaderMock = new Mock<ITaskLoader>();
        var tasks = new List<Entity.Task>();
        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Task listesi başarıyla yüklendi",
            LoadedObjectCount = tasks.Count,
            Tasks = tasks
        };
        taskLoaderMock.Setup(m => m.GetTasks()).Returns(response);
        TaskManager taskManager = new(taskLoaderMock.Object);
        taskManager.Add(new Entity.Task(null)
        {
            Title = "Odayı temizle.",
            Duration = 1,
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.S
        });
        var task1 = new Entity.Task(null)
        {
            Title = "Final sınavı için hazırlık yapmalısın",
            Duration = 6,
            DurationType = DurationType.Hour,
            TaskSize = TaskSize.M,
        };

        var actual = taskManager.GetTaskCount(TaskState.Todo);
        Assert.True(actual >= 1);
    }
}