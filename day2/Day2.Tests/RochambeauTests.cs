using Xunit;

namespace Day2.Tests;

public class RochambeauTests
{
    // A, B, C : Rock, Paper, Scissors
    // X, Y, Z : Rock, Paper, Scissors : 1, 2, 3
    // Win, Lose, Draw : 6, 3, 0
    [Theory]
    [InlineData(4, "A X")]
    [InlineData(8, "A Y")]
    [InlineData(3, "A Z")]
    [InlineData(1, "B X")]
    [InlineData(5, "B Y")]
    [InlineData(9, "B Z")]
    [InlineData(7, "C X")]
    [InlineData(2, "C Y")]
    [InlineData(6, "C Z")]
    public void AssumedScoreTests(int expectedScore, string strategy)
    {
        var actualScore = Rochambeau.AssumedScore(strategy);
        
        Assert.Equal(expectedScore, actualScore);
    }

    // A, B, C : Rock, Paper, Scissors : 1, 2, 3
    // X, Y, Z : Lose, Draw, Win : 0, 3, 6
    [Theory]
    [InlineData(3, "A X")]
    [InlineData(4, "A Y")]
    [InlineData(8, "A Z")]
    [InlineData(1, "B X")]
    [InlineData(5, "B Y")]
    [InlineData(9, "B Z")]
    [InlineData(2, "C X")]
    [InlineData(6, "C Y")]
    [InlineData(7, "C Z")]
    public void SpecifiedScoreTests(int expectedScore, string strategy)
    {
        var actualScore = Rochambeau.SpecifiedScore(strategy);
        
        Assert.Equal(expectedScore, actualScore);
    }
}