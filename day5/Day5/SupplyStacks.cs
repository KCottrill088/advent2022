using System.Text.RegularExpressions;

var crates = File.ReadAllLines("data/crates.example");

var stacks = new[] { new Stack<char>() };

foreach (var crate in InputHandler.GetCrates(crates))
{
    foreach (var supply in crate)
    {
        
    }
}

var i = 0;
while (!Regex.Match(crates[i], @"^\s+\d").Success)
{
    var part = crates[i].Take(4);
    Console.WriteLine(part);
    Console.WriteLine(crates[i]);
    i++;
}

public static class InputHandler
{
    public static IEnumerable<string> SplitRow(string input)
    {
        var row = new List<string>();
        var i = 0;
        while (i + 2 <= input.Length)
        {
            var token = input.Substring(i + 1, 1);
            row.Add(token);
            i += 4;
        }

        return row;
    }

    public static IList<string> GetCrates(string[] input)
    {
        var crates = new List<string>();
        var i = 0;
        while (!Regex.Match(input[i], @"^\s+\d").Success)
        {
            crates.Add(input[i]);
            i++;
        }

        return crates;
    }
}