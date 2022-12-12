var gridInput = File.ReadAllLines("data/grid.dat");
var grid = new List<IList<int>>(gridInput.Length);
grid.AddRange(gridInput.Select(StringToDigits));

var visibleTrees = 0;
var maxScenicScore = 0;
for (var row = 0; row < grid.Count; row++)
{
    for (var col = 0; col < grid.Count; col++)
    {
        if (Check.Visible(grid, row, col))
            visibleTrees++;
        maxScenicScore = Math.Max(maxScenicScore, Check.ScenicScore(grid, row, col));
    }
}
Console.WriteLine($"{visibleTrees} trees are visible.");
Console.WriteLine($"{maxScenicScore} is the highest scenic score.");

static IList<int> StringToDigits(string input)
{
    var digits = new List<int>();
    foreach(var c in input)
        if (int.TryParse(c.ToString(), out var d))
            digits.Add(d);
    return digits;
}

public static class Check
{
    public static bool Visible(IList<IList<int>> grid, int row, int col)
    {
        if (row == 0 || col == 0)
            return true;
        var maxIndex = grid.Count - 1;
        if (row == maxIndex || col == maxIndex)
            return true;

        var maxHeight = 0;
        for (var x = 0; x < col; x++)
            maxHeight = Math.Max(maxHeight, grid[row][x]);
        if (grid[row][col] > maxHeight) return true;

        maxHeight = 0;
        for (var x = maxIndex; x > col; x--)
            maxHeight = Math.Max(maxHeight, grid[row][x]);
        if (grid[row][col] > maxHeight) return true;

        maxHeight = 0;
        for (var y = 0; y < row; y++)
            maxHeight = Math.Max(maxHeight, grid[y][col]);
        if (grid[row][col] > maxHeight) return true;

        maxHeight = 0;
        for (var y = maxIndex; y > row; y--)
            maxHeight = Math.Max(maxHeight, grid[y][col]);
        return grid[row][col] > maxHeight;
    }

    public static int ScenicScore(List<IList<int>> grid, int row, int col)
    {
        var visibleTrees = 0;
        for (var x = col - 1; x >= 0; x--)
        {
            visibleTrees++;
            if (grid[row][x] >= grid[row][col])
                break;
        }
        var scenicScore = visibleTrees;

        visibleTrees = 0;
        for (var x = col + 1; x < grid.Count; x++)
        {
            visibleTrees++;
            if (grid[row][x] >= grid[row][col])
                break;
        }
        scenicScore *= visibleTrees;
        
        visibleTrees = 0;
        for (var y = row - 1; y >= 0; y--)
        {
            visibleTrees++;
            if (grid[y][col] >= grid[row][col])
                break;
        }
        scenicScore *= visibleTrees;

        visibleTrees = 0;
        for (var y = row + 1; y < grid.Count; y++)
        {
            visibleTrees++;
            if (grid[y][col] >= grid[row][col])
                break;
        }
        scenicScore *= visibleTrees;
        
        return scenicScore;
    }
}
