using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace Day9.Tests;

public class RopeTests
{
    [Theory]
    [InlineData('U', 1, 0, 1, 0, 0, 1)]
    [InlineData('U', 2, 0, 2, 0, 1, 2)]
    [InlineData('D', 1, 0, -1, 0, 0, 1)]
    [InlineData('D', 2, 0, -2, 0, -1, 2)]
    [InlineData('R', 1, 1, 0, 0, 0, 1)]
    [InlineData('R', 2, 2, 0, 1, 0, 2)]
    [InlineData('L', 1, -1, 0, 0, 0, 1)]
    [InlineData('L', 2, -2, 0, -1, 0, 2)]
    public void MoveTests(char direction, int distance, int headX, int headY, int tailX, int tailY, int expectedVisited)
    {
        var rope = new Rope(2);
        var move = new MoveInput(direction, distance);
        var expectedHeadPosition = new Position(headX, headY);
        var expectedTailPosition = new Position(tailX, tailY);

        rope.Move(move);
        
        Assert.Equal(expectedHeadPosition, rope.Head);
        Assert.Equal(expectedTailPosition, rope.Tail);
        Assert.Equal(expectedVisited, rope.Visited);
    }
}
