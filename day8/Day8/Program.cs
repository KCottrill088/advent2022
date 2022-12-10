var gridInput = File.ReadAllLines("data/grid.example");
var grid = new List<IList<int>>(gridInput.Length);
grid.AddRange(gridInput.Select(InputConverter.StringToDigits));

foreach (var row in grid)
{
    foreach (var tree in row)
        Console.Write(tree);
    Console.WriteLine();
}

public static class Check
{
    public static IList<int> Visibility(IList<int> row)
    {
        var visible = new int[row.Count - 2];

        return visible;
    }
}

static class InputConverter
{
    internal static IList<int> StringToDigits(string input)
    {
        var digits = new List<int>();
        foreach(var c in input)
            if (int.TryParse(c.ToString(), out var d))
                digits.Add(d);
        return digits;
    }
}