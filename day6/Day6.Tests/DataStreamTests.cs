using Xunit;

namespace Day6.Tests;

public class DataStreamTests
{
    [Theory]
    [InlineData(14, 19, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")]
    [InlineData(14, 23, "bvwbjplbgvbhsrlpgdmjqwftvncz")]
    [InlineData(14, 23, "nppdvjthqldpwncqszvftbrmjlhg")]
    [InlineData(14, 29, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")]
    [InlineData(14, 26, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")]
    [InlineData(4, 7, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")]
    [InlineData(4, 5, "bvwbjplbgvbhsrlpgdmjqwftvncz")]
    [InlineData(4, 6, "nppdvjthqldpwncqszvftbrmjlhg")]
    [InlineData(4, 10, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")]
    [InlineData(4, 11, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")]
    public void StartOfWindowTests(int size, int expectedStartOfMessage, string dataStream)
    {
        var actual = DataStream.StartOfWindow(dataStream, size);
        
        Assert.Equal(expectedStartOfMessage, actual);
    }
}