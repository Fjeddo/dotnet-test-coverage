using Xunit;

namespace TheClassLib.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var result = Class1.Hello();

        Assert.Equal("World!", result);
    }
}