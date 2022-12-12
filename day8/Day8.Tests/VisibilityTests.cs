using System.Collections.Generic;
using Xunit;

namespace Day8.Tests;

public class VisibilityTests
{
    private readonly List<IList<int>> _grid;

    public VisibilityTests()
    {
        _grid = new List<IList<int>>
        {
            new List<int> { 1, 3, 5, 7, 9 },
            new List<int> { 3, 4, 5, 4, 7 },
            new List<int> { 5, 5, 5, 5, 5 },
            new List<int> { 7, 4, 5, 4, 3 },
            new List<int> { 9, 7, 5, 3, 1 }
        };
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(0, 0, 1)]
    [InlineData(0, 0, 2)]
    [InlineData(0, 0, 3)]
    [InlineData(0, 0, 4)]
    public void CheckScenicScoreTests(int expectedScenicScore, int row, int col)
    {
        var scenicScore = Check.ScenicScore(_grid, row, col);
        
        Assert.Equal(expectedScenicScore, scenicScore);
    }

    [Theory]
    [InlineData(true, 1, 1)]
    [InlineData(true, 1, 2)]
    [InlineData(false, 1, 3)]
    [InlineData(true, 2, 1)]
    [InlineData(false, 2, 2)]
    [InlineData(true, 2, 3)]
    [InlineData(false, 3, 1)]
    [InlineData(true, 3, 2)]
    [InlineData(true, 3, 3)]
    public void CheckVisibilityTests(bool expectedVisibility, int row, int col)
    {
        var visible = Check.Visible(_grid, row, col);
        
        Assert.Equal(expectedVisibility, visible);
    }
}