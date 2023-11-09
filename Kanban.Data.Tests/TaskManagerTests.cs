namespace Kanban.Data.Tests;

// Bu birim test sınıfı TaskManager sınıfının metotlarına ait testleri içerir
public class TaskManagerTests
{
    // Fact niteliği(attribute) ile işaretlenmiş metotlar test metotlarıdır.
    // Runtime için ayrı bir anlam ifade ederler.
    // Belli kabul kriterlerinin doğruluğunu onaylamak için kullanılırlar
    [Fact]
    public void Create_TaskManager_Returns_Filled_Task_List_Test()
    {
        TaskManager taskManager = new TaskManager(5);
        var actual = taskManager.GetTaskCount(Entity.TaskState.Todo);
        var expected = 5;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Add_New_Task_Returns_Valid_Id_Test()
    {
        TaskManager taskManager = new TaskManager(5);
        var actual = taskManager.Add(new Entity.Task
        {

        });
        Assert.True(actual > 0);
    }
    
    [Fact(Skip = "Geçici olarak devre dışı")]
    public void Add_Existing_Task_Returns_Zero_Id_Test()
    {

    }
}