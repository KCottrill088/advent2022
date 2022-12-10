using Xunit;

namespace Day7.Tests;

public class InterpreterTests
{
    [Fact]
    public void DispatchTests()
    {
        var actual = Interpreter.Dispatch(@"$ cd /");
        
        Assert.Equal(@"$ cd /", actual);
    }
}