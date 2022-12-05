using Xunit;

namespace Day4.Tests;

public class PairInspectorTests
{
    [Theory]
    [InlineData(false, "1-1,3-5")]
    [InlineData(false, "2-2,3-5")]
    [InlineData(false, "2-3,3-5")]
    [InlineData(false, "5-6,3-5")]
    [InlineData(false, "6-6,3-5")]
    [InlineData(false, "7-7,3-5")]
    [InlineData(false, "3-5,1-1")]
    [InlineData(false, "3-5,2-2")]
    [InlineData(false, "3-5,2-3")]
    [InlineData(false, "3-5,5-6")]
    [InlineData(false, "3-5,6-6")]
    [InlineData(false, "3-5,7-7")]
    [InlineData(true, "2-5,3-5")]
    [InlineData(true, "3-5,3-5")]
    [InlineData(true, "4-5,3-5")]
    [InlineData(true, "3-4,3-5")]
    [InlineData(true, "3-3,3-5")]
    [InlineData(true, "4-4,3-5")]
    [InlineData(true, "5-5,3-5")]
    [InlineData(true, "3-6,3-5")]
    [InlineData(true, "3-5,2-5")]
    [InlineData(true, "3-5,4-5")]
    [InlineData(true, "3-5,3-4")]
    [InlineData(true, "3-5,3-3")]
    [InlineData(true, "3-5,4-4")]
    [InlineData(true, "3-5,5-5")]
    [InlineData(true, "3-5,3-6")]
    public void FullyContainsTests(bool expected, string fileInput)
    {
        var pair = new Pair(fileInput);
        
        var actual = PairInspector.FullyContains(pair);
        
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, "1-1,2-2")]
    [InlineData(false, "2-2,1-1")]
    [InlineData(true, "2-2,1-2")]
    [InlineData(true, "1-2,2-2")]
    public void ContainsTests(bool expected, string fileInput)
    {
        var pair = new Pair(fileInput);

        var actual = PairInspector.Contains(pair);
        
        Assert.Equal(expected, actual);
    }
}