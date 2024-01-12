using Kanban.Contract;
using Kanban.Entity;
using Moq;

namespace Kanban.Data.Tests;

// Bu birim test sınıfı WorkItemManager sınıfının metotlarına ait testleri içerir
public class WorkItemManagerTests
{
    [Fact]
    public void Change_WorkItem_State_Works_Test()
    {
        var wi = new WorkItem(null)
        {
            Title = "Ara sınav için hazırlık yap",
            Duration = 3,
            DurationType = DurationType.Hour,
            WorkItemSize = WorkItemSize.M,
        };
        var expected = WorkItemState.Todo;
        Assert.Equal(wi.State, expected);
        wi.ChangeState();
        expected = WorkItemState.InProgress;
        Assert.Equal(wi.State, expected);
    }

    // Fact niteliği(attribute) ile işaretlenmiş metotlar test metotlarıdır.
    // Runtime için ayrı bir anlam ifade ederler.
    // Belli kabul kriterlerinin doğruluğunu onaylamak için kullanılırlar
    [Fact]
    public void Create_WorkItemManager_Returns_Filled_WorkItem_List_Test()
    {
        /*
            Bu sefer GetWorkItems metodunun dönmesi istenen içeriğini bir Mock nesnesi ile sağlıyoruz.
            Önce Moq paketinden Mock<T> nesnesi örnekliyoruz.
            GetWorkItems metodu için bir Setup kurguluyoruz ve buradan dönmesi istenen nesneyi belirliyoruz(workItemList).
            Son olarak IWorkItemLoader'a ihtiyaç duyan WorkItemManager sınıfının constructor metoduna mock nesnesini veriyoruz.
        */
        var loaderMock = new Mock<IWorkItemLoader>();
        var workItemList = new List<WorkItem>{
                new(null)
                {
                    Title = "Ara sınav için hazırlık yap",
                    Duration = 3,
                    DurationType = DurationType.Hour,
                    WorkItemSize = WorkItemSize.M,
                },
                new(null)
                {
                    Title = "Odayı temizle.",
                    Duration = 1,
                    DurationType = DurationType.Hour,
                    WorkItemSize = WorkItemSize.S
                }
        };

        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Görev listesi başarıyla yüklendi",
            LoadedObjectCount = workItemList.Count,
            WorkItems = workItemList
        };
        loaderMock.Setup(m => m.GetWorkItems()).Returns(response);
        //IWorkItemLoader workItemLoader = new FakeWorkItemLoader();
        // WorkItemManager workItemManager = new(workItemLoader);
        WorkItemManager workItemManager = new(loaderMock.Object);
        var actual = workItemManager.GetWorkItemCount(WorkItemState.Todo);
        var expected = 2;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Get_WorkItemManager_InProgress_State_Count_Test()
    {
        var workItemLoaderMock = new Mock<IWorkItemLoader>();
        var workItems = new List<WorkItem>{
                new(null)
                {
                    Title = "Ara sınav için hazırlık yap",
                    Duration = 3,
                    DurationType = DurationType.Hour,
                    WorkItemSize = WorkItemSize.M,
                },
                new(null)
                {
                    Title = "Odayı temizle.",
                    Duration = 1,
                    DurationType = DurationType.Hour,
                    WorkItemSize = WorkItemSize.S
                }
        };
        workItems[0].ChangeState();
        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Görev listesi başarıyla yüklendi",
            LoadedObjectCount = workItems.Count,
            WorkItems = workItems
        };
        workItemLoaderMock.Setup(m => m.GetWorkItems()).Returns(response);

        //WorkItemManager workItemManager = new(new FakeWorkItemLoaderWithState());
        WorkItemManager workItemManager = new(workItemLoaderMock.Object);
        var actual = workItemManager.GetWorkItemCount(WorkItemState.InProgress);
        var expected = 1;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Initiated_WorkItem_In_Todo_State_Test()
    {
        var wi1 = new WorkItem(null)
        {
            Title = "Ara sınav için hazırlık yap",
            Duration = 3,
            DurationType = DurationType.Hour,
            WorkItemSize = WorkItemSize.M,
        };
        var expected = WorkItemState.Todo;
        Assert.Equal(wi1.State, expected);
    }

    [Fact]
    public void Get_WorkItemManager_InProgress_State_List_Test()
    {
        var workItemLoaderMock = new Mock<IWorkItemLoader>();
        var workItems = new List<WorkItem>{
                new(null)
                {
                    Title = "Ara sınav için hazırlık yap",
                    Duration = 3,
                    DurationType = DurationType.Hour,
                    WorkItemSize = WorkItemSize.M,
                },
                new(null)
                {
                    Title = "Odayı temizle.",
                    Duration = 1,
                    DurationType = DurationType.Hour,
                    WorkItemSize = WorkItemSize.S
                }
        };
        workItems[0].ChangeState();
        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Görev listesi başarıyla yüklendi",
            LoadedObjectCount = workItems.Count,
            WorkItems = workItems
        };
        workItemLoaderMock.Setup(m => m.GetWorkItems()).Returns(response);
        WorkItemManager workItemManager = new(workItemLoaderMock.Object);
        var actual = workItemManager.GetWorkItems(WorkItemState.InProgress);
        Assert.True(actual.Count == 1);
    }

    [Fact]
    public void Add_New_WorkItem_Returns_Valid_Id_Test()
    {
        var workItemLoaderMock = new Mock<IWorkItemLoader>();
        var workItems = new List<WorkItem>();
        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Görev listesi başarıyla yüklendi",
            LoadedObjectCount = workItems.Count,
            WorkItems = workItems
        };
        workItemLoaderMock.Setup(m => m.GetWorkItems()).Returns(response);
        WorkItemManager workItemManager = new(workItemLoaderMock.Object);
        var actual = workItemManager.Add(new WorkItem(null)
        {
            Title = "Ara sınav için hazırlık yap",
            Duration = 3,
            DurationType = DurationType.Hour,
            WorkItemSize = WorkItemSize.M
        });
        var expected = 36;
        Assert.Equal(actual.ToString().Length, expected);
    }

    [Fact]
    public void Get_WorkItem_Test()
    {
        var workItemLoaderMock = new Mock<IWorkItemLoader>();
        var workItems = new List<WorkItem>();
        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Görev listesi başarıyla yüklendi",
            LoadedObjectCount = workItems.Count,
            WorkItems = workItems
        };
        workItemLoaderMock.Setup(m => m.GetWorkItems()).Returns(response);
        WorkItemManager workItemManager = new(workItemLoaderMock.Object);
        var wi1 = new WorkItem(null)
        {
            Title = "Ara sınav için hazırlık yap",
            Duration = 3,
            DurationType = DurationType.Hour,
            WorkItemSize = WorkItemSize.M,
        };
        workItemManager.Add(wi1);
        var expected = wi1;
        var actual = workItemManager.GetWorkItem(wi1.Id);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Get_Undefined_WorkItem_Returns_Null_Test()
    {
        var workItemLoaderMock = new Mock<IWorkItemLoader>();
        var workItems = new List<WorkItem>();
        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Görev listesi başarıyla yüklendi",
            LoadedObjectCount = workItems.Count,
            WorkItems = workItems
        };
        workItemLoaderMock.Setup(m => m.GetWorkItems()).Returns(response);
        WorkItemManager workItemManager = new(workItemLoaderMock.Object);

        var wi1 = new WorkItem(null)
        {
            Title = "Ara sınav için hazırlık yap",
            Duration = 3,
            DurationType = DurationType.Hour,
            WorkItemSize = WorkItemSize.M,
        };
        workItemManager.Add(wi1);
        var actual = workItemManager.GetWorkItem(Guid.Empty);
        Assert.True(actual == null);
    }

    [Fact]
    public void Added_New_WorkItem_Triggered_An_Event_If_Subscribed()
    {
        var workItemLoaderMock = new Mock<IWorkItemLoader>();
        var workItems = new List<WorkItem>();
        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Görev listesi başarıyla yüklendi",
            LoadedObjectCount = workItems.Count,
            WorkItems = workItems
        };
        workItemLoaderMock.Setup(m => m.GetWorkItems()).Returns(response);
        WorkItemManager workItemManager = new(workItemLoaderMock.Object);

        var eventTriggered = false;
        workItemManager.newWorkItemAdded += (source, eventArgs) =>
        {
            eventTriggered = true;
        };
        var wi1 = new WorkItem(null)
        {
            Title = "Arkadaşlarına hediye etmek üzere okuduklarından 10 kitap ayır",
            Duration = 3,
            DurationType = DurationType.Hour,
            WorkItemSize = WorkItemSize.S,
        };
        workItemManager.Add(wi1);
        var expected = true;
        Assert.Equal(expected, eventTriggered);
    }

    [Fact]
    public void Added_New_WorkItem_Do_Not_Triggered_An_Event_If_Not_Exist()
    {
        var workItemLoaderMock = new Mock<IWorkItemLoader>();
        var workItems = new List<WorkItem>();
        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Görev listesi başarıyla yüklendi",
            LoadedObjectCount = workItems.Count,
            WorkItems = workItems
        };
        workItemLoaderMock.Setup(m => m.GetWorkItems()).Returns(response);
        WorkItemManager workItemManager = new(workItemLoaderMock.Object);

        var eventTriggered = false;
        var wi1 = new WorkItem(null)
        {
            Title = "Arkadaşlarına hediye etmek üzere okuduklarından 10 kitap ayır",
            Duration = 3,
            DurationType = DurationType.Hour,
            WorkItemSize = WorkItemSize.S,
        };
        workItemManager.Add(wi1);
        var expected = false;
        Assert.Equal(expected, eventTriggered);
    }


    [Fact(Skip = "Geçici olarak devre dışı")]
    public void Add_Existing_WorkItem_Returns_Zero_Id_Test()
    {
    }

    [Fact]
    public void Save_All_WorkItems_To_CSV_File_Return_Success_Test()
    {
        var workItemLoaderMock = new Mock<IWorkItemLoader>();
        var workItems = new List<WorkItem>();
        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Görev listesi başarıyla yüklendi",
            LoadedObjectCount = workItems.Count,
            WorkItems = workItems
        };
        workItemLoaderMock.Setup(m => m.GetWorkItems()).Returns(response);
        WorkItemManager workItemManager = new(workItemLoaderMock.Object);

        workItemManager.Add(new WorkItem(null)
        {
            Title = "Odayı temizle.",
            Duration = 1,
            DurationType = DurationType.Hour,
            WorkItemSize = WorkItemSize.S
        });
        var wi1 = new Entity.WorkItem(null)
        {
            Title = "Final sınavı için hazırlık yapmalısın",
            Duration = 6,
            DurationType = DurationType.Hour,
            WorkItemSize = WorkItemSize.M,
        };
        workItemManager.Add(wi1);
        wi1.ChangeState();
        var wi2 = new WorkItem(null)
        {
            Title = "Denizler Altında 20bin Fersah kitabının özeti çıkartılacak",
            Duration = 3,
            DurationType = DurationType.Month,
            WorkItemSize = WorkItemSize.XL,
        };
        workItemManager.Add(wi2);
        wi2.ChangeState();
        wi2.ChangeState();
        var actual = workItemManager.Save(new FakeWorkItemSaver());
        var expected = true;
        Assert.Equal(expected, actual.IsSuccess);

        // Assert.True(actual);
        // Assert.True(workItemManager.Save("Board"));
    }

    [Fact]
    public void Save_All_WorkItems_To_CSV_File_Return_Fail_Test()
    {
        var workItemLoaderMock = new Mock<IWorkItemLoader>();
        var workItems = new List<WorkItem>();
        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Görev listesi başarıyla yüklendi",
            LoadedObjectCount = workItems.Count,
            WorkItems = workItems
        };
        workItemLoaderMock.Setup(m => m.GetWorkItems()).Returns(response);
        WorkItemManager workItemManager = new(workItemLoaderMock.Object);

        workItemManager.Add(new WorkItem(null)
        {
            Title = "Odayı temizle.",
            Duration = 1,
            DurationType = DurationType.Hour,
            WorkItemSize = WorkItemSize.S
        });
        var wi1 = new WorkItem(null)
        {
            Title = "Final sınavı için hazırlık yapmalısın",
            Duration = 6,
            DurationType = DurationType.Hour,
            WorkItemSize = WorkItemSize.M,
        };
        workItemManager.Add(wi1);
        wi1.ChangeState();
        var wi2 = new WorkItem(null)
        {
            Title = "Denizler Altında 20bin Fersah kitabının özeti çıkartılacak",
            Duration = 3,
            DurationType = DurationType.Month,
            WorkItemSize = WorkItemSize.XL,
        };
        workItemManager.Add(wi2);
        wi2.ChangeState();
        wi2.ChangeState();
        var actual = workItemManager.Save(new FakeWorkItemSaverInFail());
        Assert.False(actual.IsSuccess);
        Assert.Equal(new FileNotFoundException().Message, actual.Exception == null ? "" : actual.Exception.Message);
    }

    [Fact]
    public void Load_WorkItems_From_File_Test()
    {
        var workItemLoaderMock = new Mock<IWorkItemLoader>();
        var workItems = new List<WorkItem>();
        var response = new LoadResponse
        {
            IsSuccess = true,
            Exception = null,
            Message = "Görev listesi başarıyla yüklendi",
            LoadedObjectCount = workItems.Count,
            WorkItems = workItems
        };
        workItemLoaderMock.Setup(m => m.GetWorkItems()).Returns(response);
        WorkItemManager workItemManager = new(workItemLoaderMock.Object);
        workItemManager.Add(new WorkItem(null)
        {
            Title = "Odayı temizle.",
            Duration = 1,
            DurationType = DurationType.Hour,
            WorkItemSize = WorkItemSize.S
        });
        var wi1 = new WorkItem(null)
        {
            Title = "Final sınavı için hazırlık yapmalısın",
            Duration = 6,
            DurationType = DurationType.Hour,
            WorkItemSize = WorkItemSize.M,
        };

        var actual = workItemManager.GetWorkItemCount(WorkItemState.Todo);
        Assert.True(actual >= 1);
    }
}