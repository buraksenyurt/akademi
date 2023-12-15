namespace Transformer.Tests;

public class UsageTest
{
    [Fact]
    public void Main_Arguments_Length_Is_Invalid_Test()
    {
        var actual = Converter.CheckArguments(Array.Empty<string>());
        var expected = new Response { IsError = true, Message = Messages.InvalidArgument };
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Main_Arguments_Length_Is_Valid_Test()
    {
        var dummyFile = Path.Combine(Environment.CurrentDirectory, "somefile.txt");
        File.Create(dummyFile);

        var actual = Converter.CheckArguments(new string[] { dummyFile, "TargetFile.dat", "Base64Encoded" });
        var expected = new Response { IsError = false, Message = Messages.EverythingIsOk };
        Assert.Equal(expected, actual);

        File.Delete(dummyFile);
    }

    [Theory]
    [InlineData("")]
    [InlineData("bla bla bla")]
    [InlineData("     ")]
    public void Target_Format_Is_Invalid_Test(string targetFormat)
    {
        var actual = Converter.CheckArguments(new string[] { "SourceFile.txt", "TargetFile.dat", targetFormat });
        var expected = new Response { IsError = true, Message = Messages.InvalidTargetFormat };
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("OnlyBytes")]
    [InlineData("Base64Encoded")]
    [InlineData("Zipped")]
    public void Target_Format_Valid_Test(string targetFormat)
    {
        var dummyFile = Path.Combine(Environment.CurrentDirectory, "somefile.txt");
        File.Create(dummyFile);

        var actual = Converter.CheckArguments(new string[] { dummyFile, "TargetFile.dat", targetFormat });
        var expected = new Response { IsError = false, Message = Messages.EverythingIsOk };
        Assert.Equal(expected, actual);

        File.Delete(dummyFile);
    }

    [Fact]
    public void Source_File_Does_Not_Exists_Test()
    {
        var actual = Converter.CheckArguments(new string[] { "ThisFileDoesNotExists.nan", "TargetFile.dat", "Base64Encoded" });
        var expected = new Response { IsError = true, Message = Messages.SourceFileDoesNotExist };
        Assert.Equal(expected, actual);
    }
}