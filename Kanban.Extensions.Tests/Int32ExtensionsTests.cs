using Kanban.Entity;

namespace Kanban.Extensions.Tests;

public class Int32ExtensionsTests
{
    [Fact]
    public void Should_1_Convert_To_Small_Size_Task()
    {
        var value = 1;
        var actual = value.ConvertToTaskSize();
        var expected = TaskSize.S;
        Assert.Equal(actual, expected);
    }

    [Fact]
    public void Should_5_Convert_To_Small_Size_Task()
    {
        var value = 5;
        var actual = value.ConvertToTaskSize();
        var expected = TaskSize.S;
        Assert.Equal(actual, expected);
    }

    [Fact]
    public void Should_7_Convert_To_Medium_Size_Task()
    {
        var value = 7;
        var actual = value.ConvertToTaskSize();
        var expected = TaskSize.M;
        Assert.Equal(actual, expected);
    }

    [Fact]
    public void Should_15_Convert_To_Large_Size_Task()
    {
        var value = 15;
        var actual = value.ConvertToTaskSize();
        var expected = TaskSize.L;
        Assert.Equal(actual, expected);
    }

    [Fact]
    public void Should_50_Convert_To_XLarge_Size_Task()
    {
        var value = 50;
        var actual = value.ConvertToTaskSize();
        var expected = TaskSize.XL;
        Assert.Equal(actual, expected);
    }

    [Fact]
    public void Should_0_Convert_To_NA_Size_Task()
    {
        var value = 0;
        var actual = value.ConvertToTaskSize();
        var expected = TaskSize.NA;
        Assert.Equal(actual, expected);
    }

    [Fact]
    public void Should_81_Convert_To_NA_Size_Task()
    {
        var value = 81;
        var actual = value.ConvertToTaskSize();
        var expected = TaskSize.NA;
        Assert.Equal(actual, expected);
    }
}