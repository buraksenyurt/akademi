using Kanban.Entity;

namespace Kanban.Extensions.Tests;

public class Int32ExtensionsTests
{
    [Fact]
    public void Should_1_Convert_To_Small_Size_WorkItem()
    {
        var value = 1;
        var actual = value.ConvertToWorkItemSize();
        var expected = WorkItemSize.S;
        Assert.Equal(actual, expected);
    }

    [Fact]
    public void Should_5_Convert_To_Small_Size_WorkItem()
    {
        var value = 5;
        var actual = value.ConvertToWorkItemSize();
        var expected = WorkItemSize.S;
        Assert.Equal(actual, expected);
    }

    [Fact]
    public void Should_7_Convert_To_Medium_Size_WorkItem()
    {
        var value = 7;
        var actual = value.ConvertToWorkItemSize();
        var expected = WorkItemSize.M;
        Assert.Equal(actual, expected);
    }

    [Fact]
    public void Should_15_Convert_To_Large_Size_WorkItem()
    {
        var value = 15;
        var actual = value.ConvertToWorkItemSize();
        var expected = WorkItemSize.L;
        Assert.Equal(actual, expected);
    }

    [Fact]
    public void Should_50_Convert_To_XLarge_Size_WorkItem()
    {
        var value = 50;
        var actual = value.ConvertToWorkItemSize();
        var expected = WorkItemSize.XL;
        Assert.Equal(actual, expected);
    }

    [Fact]
    public void Should_0_Convert_To_NA_Size_WorkItem()
    {
        var value = 0;
        var actual = value.ConvertToWorkItemSize();
        var expected = WorkItemSize.NA;
        Assert.Equal(actual, expected);
    }

    [Fact]
    public void Should_81_Convert_To_NA_Size_WorkItem()
    {
        var value = 81;
        var actual = value.ConvertToWorkItemSize();
        var expected = WorkItemSize.NA;
        Assert.Equal(actual, expected);
    }
}