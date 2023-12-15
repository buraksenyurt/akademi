namespace Transformer.Tests;

public class UsageTest
{
    [Fact]
    public void Main_Arguments_Length_Is_Invalid_Test()
    {
        Converter converter = new();
        var actual = converter.CheckArguments(Array.Empty<string>());
        var expected = new Response { IsError = true, Message = ResponseMessages.InvalidArgument };
        Assert.Equal(expected.IsError, actual.IsError);
        Assert.Equal(expected.Message, actual.Message);
    }

    [Fact]
    public void Main_Arguments_Length_Is_Valid_Test()
    {
        var dummyFile = Path.Combine(Environment.CurrentDirectory, "somefile.txt");
        File.Create(dummyFile);

        Converter converter = new();
        var actual = converter.CheckArguments(new string[] { dummyFile, "TargetFile.dat", "Base64Encoded" });
        var expected = new Response { IsError = false, Message = ResponseMessages.EverythingIsOk };
        Assert.Equal(expected.IsError, actual.IsError);
        Assert.Equal(expected.Message, actual.Message);

        File.Delete(dummyFile);
    }

    [Theory]
    [InlineData("")]
    [InlineData("bla bla bla")]
    [InlineData("     ")]
    public void Target_Format_Is_Invalid_Test(string targetFormat)
    {
        Converter converter = new();
        var actual = converter.CheckArguments(new string[] { "SourceFile.txt", "TargetFile.dat", targetFormat });
        var expected = new Response { IsError = true, Message = ResponseMessages.InvalidTargetFormat };
        Assert.Equal(expected.IsError, actual.IsError);
        Assert.Equal(expected.Message, actual.Message);
    }

    [Theory]
    [InlineData("OnlyBytes")]
    [InlineData("Base64Encoded")]
    [InlineData("Zipped")]
    public void Target_Format_Valid_Test(string targetFormat)
    {
        var dummyFile = Path.Combine(Environment.CurrentDirectory, "somefile.txt");
        File.Create(dummyFile);

        Converter converter = new();
        var actual = converter.CheckArguments(new string[] { dummyFile, "TargetFile.dat", targetFormat });
        var expected = new Response { IsError = false, Message = ResponseMessages.EverythingIsOk };
        Assert.Equal(expected.IsError, actual.IsError);
        Assert.Equal(expected.Message, actual.Message);

        File.Delete(dummyFile);
    }

    [Fact]
    public void Source_File_Does_Not_Exists_Test()
    {
        Converter converter = new();
        var actual = converter.CheckArguments(new string[] { "ThisFileDoesNotExists.nan", "TargetFile.dat", "Base64Encoded" });
        var expected = new Response { IsError = true, Message = ResponseMessages.SourceFileDoesNotExist };
        Assert.Equal(expected.IsError, actual.IsError);
        Assert.Equal(expected.Message, actual.Message);
    }
}