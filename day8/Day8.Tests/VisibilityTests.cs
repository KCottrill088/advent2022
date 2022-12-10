using System.ComponentModel.Design;
using Xunit;

namespace Day8.Tests;

public class VisibilityTests
{
    [Fact]
    public void CheckVisibilityTests()
    {
        var input = new[] { 3, 0, 3, 7, 3 };

        var actual = Check.Visibility(input);
        
        Assert.Equal(new[] { 0, 0, 1 }, actual);

    }
}