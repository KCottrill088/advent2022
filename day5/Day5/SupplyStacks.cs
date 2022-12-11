using System.Text.RegularExpressions;

var input = File.ReadAllLines("data/crates.dat");
var crates = new List<string>();
foreach (var row in input)
{
    if (Regex.Match(row, @"^(\s+\d+)+").Success) break;
    crates.Add(row);
}
crates.Reverse();

var stacks = new List<Stack<char>>();
foreach (var row in crates)
{
    for (var i = 0; i < row.Length; i += 4)
    {
        if (i / 4 == stacks.Count)
            stacks.Add(new Stack<char>());

        var item = row[i + 1];
        if (item != ' ')
            stacks[i / 4].Push(item);
    }
}

var moves = new List<Move>();
foreach (var row in input)
{
    if (!Regex.Match(row, @"^move").Success) continue;
    if (row.Length == 18)
    {
        moves.Add(new Move(
            int.Parse(row.Substring(5, 1)),
            int.Parse(row.Substring(12, 1)) - 1,
            int.Parse(row.Substring(17, 1)) - 1));
    }
    else
    {
        moves.Add(new Move(
            int.Parse(row.Substring(5, 2)),
            int.Parse(row.Substring(13, 1)) - 1,
            int.Parse(row.Substring(18, 1)) - 1));
    }
}

foreach (var move in moves)
{
    var toMove = new List<char>();
    for (var i = 0; i < move.Quantity; i++)
    {
        var item = stacks[move.Source].Pop();
        toMove.Add(item);
        // stacks[move.Destination].Push(item);
    }
    toMove.Reverse();
    toMove.ForEach(i => stacks[move.Destination].Push(i));
}

stacks.ForEach(s => Console.Write(s.Peek()));
Console.WriteLine();

internal record Move(int Quantity, int Source, int Destination);
