using Xunit;

namespace Day9.Tests;

public class RopeTests
{
    [Theory]
    [InlineData('U', 1, 0, 1, 0, 0)]
    [InlineData('U', 2, 0, 2, 0, 1)]
    [InlineData('D', 1, 0, -1, 0, 0)]
    [InlineData('D', 2, 0, -2, 0, -1)]
    [InlineData('R', 1, 1, 0, 0, 0)]
    [InlineData('R', 2, 2, 0, 1, 0)]
    [InlineData('L', 1, -1, 0, 0, 0)]
    [InlineData('L', 2, -2, 0, -1, 0)]
    public void MoveTests(char direction, int distance, int headX, int headY, int tailX, int tailY)
    {
        var rope = new Rope();
        var move = new MoveInput(direction, distance);
        var expectedHeadPosition = new Position(headX, headY);
        var expectedTailPosition = new Position(tailX, tailY);

        rope.Move(move);
        
        Assert.Equal(expectedHeadPosition, rope.Head);
        Assert.Equal(expectedTailPosition, rope.Tail);
    }
}