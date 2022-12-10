using System.Linq;
using Xunit;

namespace Day5.Tests;

public class SupplyStacksTests
{
    [Theory]
    [InlineData("    [D]", new[] { " ", "D" })]
    [InlineData("[N] [C]", new[] { "N", "C" })]
    [InlineData("[Z] [M] [P]", new[] { "Z", "M", "P" })]
    public void InputLineSplitterTests(string input, string[] expectedRow)
    {
        var actualRow = InputHandler.SplitRow(input);
        
        Assert.Equal(expectedRow, actualRow);
    }

    [Fact]
    public void GetCratesTests()
    {
        var input = new[]
        {
            "[N] [C]",
            "[Z] [M] [P]",
            " 1   2   3",
            "",
            "move 1 from 2 to 1"
        };

        var actual = InputHandler.GetCrates(input);

        Assert.Equal(2, actual.Count);
        Assert.Equal("[N] [C]", actual.First());
        Assert.Equal("[Z] [M] [P]", actual.Last());
    }
}
