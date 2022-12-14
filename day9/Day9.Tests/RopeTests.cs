using Xunit;

namespace Day9.Tests;

public class RopeTests
{
    [Fact]
    public void MoveTests()
    {
        var rope = new Rope();
        var move = new MoveInput('U', 1);
        var expectedHeadPosition = new Position(0, 1);
        var expectedTailPosition = new Position(0, 0);

        rope.Move(move);
        
        Assert.Equal(expectedHeadPosition, rope.Head);
        Assert.Equal(expectedTailPosition, rope.Tail);
    }
}