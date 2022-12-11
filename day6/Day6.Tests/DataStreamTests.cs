using System.Runtime.InteropServices;
using Xunit;

namespace Day6.Tests;

public class DataStreamTests
{
    [Theory]
    [InlineData(7, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")]
    [InlineData(5, "bvwbjplbgvbhsrlpgdmjqwftvncz")]
    [InlineData(6, "nppdvjthqldpwncqszvftbrmjlhg")]
    [InlineData(10, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")]
    [InlineData(11, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")]
    public void StartOfPacketTests(int expectedStartOfPacket, string dataStream)
    {
        var actual = DataStream.StartOfPacket(dataStream);
        
        Assert.Equal(expectedStartOfPacket, actual);
    }
}