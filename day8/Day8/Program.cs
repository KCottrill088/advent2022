var gridInput = File.ReadAllLines("data/grid.dat");
var grid = new List<IList<int>>(gridInput.Length);
grid.AddRange(gridInput.Select(StringToDigits));

var visibleTrees = 0;
for (var row = 0; row < grid.Count; row++)
{
    for (var col = 0; col < grid.Count; col++)
    {
        Console.Write(grid[row][col]);
        if (Check.Visible(grid, row, col))
            visibleTrees++;
    }
    Console.WriteLine();
}
Console.WriteLine($"{visibleTrees} trees are visible.");

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
    public static bool Visible(List<IList<int>> treeGrid, int row, int col)
    {
        if (row == 0 || col == 0)
            return true;
        var maxIndex = treeGrid.Count - 1;
        if (row == maxIndex || col == maxIndex)
            return true;

        var maxHeight = 0;
        for (var z = 0; z < col; z++)
        {
            maxHeight = Math.Max(maxHeight, treeGrid[row][z]);
        }
        if (treeGrid[row][col] > maxHeight) return true;

        maxHeight = 0;
        for (var z = maxIndex; z > col; z--)
        {
            maxHeight = Math.Max(maxHeight, treeGrid[row][z]);
        }
        if (treeGrid[row][col] > maxHeight) return true;

        maxHeight = 0;
        for (var z = 0; z < row; z++)
        {
            maxHeight = Math.Max(maxHeight, treeGrid[z][col]);
        }
        if (treeGrid[row][col] > maxHeight) return true;

        maxHeight = 0;
        for (var z = maxIndex; z > row; z--)
        {
            maxHeight = Math.Max(maxHeight, treeGrid[z][col]);
        }
        if (treeGrid[row][col] > maxHeight) return true;

        return false;
    }
}
