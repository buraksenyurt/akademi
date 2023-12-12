using System.Runtime.InteropServices;
using Kanban.Entity;

namespace Kanban.Extensions.Tests;

public class StringExtensionsTests
{
    /*
        Birim test fonksiyonlarında aşağıdaki gibi birden fazla input değerini kontrol etmek oldukça yaygındır.
        Aşağıdaki test metodu string tipine eklenmi ToTaskSize metodunun testini yapmaktadır.
        s, small, SMALL, SmalL, SmALl vs gibi bilgiler bu genişletme metoduna göre TaskSize.S olarak dönüştürülmelidir.
        Her bir durum için ayrı birer test metodu yazmak yerine Theory ve InlineData niteliklerini(attribute) kullanarak
        tüm veriler için tek bir birim test metodu yazabiliriz.
    */
    [Theory]
    [InlineData("s", TaskSize.S)]
    [InlineData("S", TaskSize.S)]
    [InlineData("small", TaskSize.S)]
    [InlineData("SMALL", TaskSize.S)]
    [InlineData("sMaLl", TaskSize.S)]
    [InlineData("SMaLl", TaskSize.S)]
    [InlineData("m", TaskSize.M)]
    [InlineData("M", TaskSize.M)]
    [InlineData("medium", TaskSize.M)]
    [InlineData("MEDIUM", TaskSize.M)]
    [InlineData("mEdiUM", TaskSize.M)]
    [InlineData("l", TaskSize.L)]
    [InlineData("large", TaskSize.L)]
    [InlineData("xl", TaskSize.XL)]
    [InlineData("xlarge", TaskSize.XL)]
    public void Should_string_Convert_To_Available_Size_Task(string value, TaskSize expected)
    {
        var actual = value.ToTaskSize();
        Assert.Equal(actual, expected);
    }
}