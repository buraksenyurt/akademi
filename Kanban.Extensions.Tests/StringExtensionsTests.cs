using Kanban.Entity;

namespace Kanban.Extensions.Tests;

public class StringExtensionsTests
{
    /*
        Birim test fonksiyonlarında aşağıdaki gibi birden fazla input değerini kontrol etmek oldukça yaygındır.
        Aşağıdaki test metodu string tipine eklenmi ToWorkItemSize metodunun testini yapmaktadır.
        s, small, SMALL, SmalL, SmALl vs gibi bilgiler bu genişletme metoduna göre WorkItemSize.S olarak dönüştürülmelidir.
        Her bir durum için ayrı birer test metodu yazmak yerine Theory ve InlineData niteliklerini(attribute) kullanarak
        tüm veriler için tek bir birim test metodu yazabiliriz.
    */
    [Theory]
    [InlineData("s", WorkItemSize.S)]
    [InlineData("S", WorkItemSize.S)]
    [InlineData("small", WorkItemSize.S)]
    [InlineData("SMALL", WorkItemSize.S)]
    [InlineData("sMaLl", WorkItemSize.S)]
    [InlineData("SMaLl", WorkItemSize.S)]
    [InlineData("m", WorkItemSize.M)]
    [InlineData("M", WorkItemSize.M)]
    [InlineData("medium", WorkItemSize.M)]
    [InlineData("MEDIUM", WorkItemSize.M)]
    [InlineData("mEdiUM", WorkItemSize.M)]
    [InlineData("l", WorkItemSize.L)]
    [InlineData("large", WorkItemSize.L)]
    [InlineData("xl", WorkItemSize.XL)]
    [InlineData("xlarge", WorkItemSize.XL)]
    [InlineData("what did you say?", WorkItemSize.NA)]
    public void Should_string_Convert_To_Available_Size_WorkItem(string value, WorkItemSize expected)
    {
        var actual = value.ToWorkItemSize();
        Assert.Equal(actual, expected);
    }

    [Theory]
    [InlineData('h', DurationType.Hour)]
    [InlineData('d', DurationType.Day)]
    [InlineData('w', DurationType.Week)]
    [InlineData('m', DurationType.Month)]
    [InlineData('y', DurationType.Year)]
    [InlineData('x', DurationType.NA)]
    public void Should_char_Convert_To_Available_Duration_Type(char value, DurationType expected)
    {
        var actual = value.ToDurationType();
        Assert.Equal(actual, expected);
    }
}