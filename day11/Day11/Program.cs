using System.Text.RegularExpressions;

var input = File.ReadAllLines("/home/kevin/repos/advent2022/day11/Day11/data/monkeys.example");
var monkeys = new List<Monkey>();
input.ToList().ForEach(line =>
{
    var monkeyLine = Regex.Match(line, @"^Monkey\s+(\d+):"); 
    if (monkeyLine.Success)
    {
        var monkey = new Monkey(int.Parse(monkeyLine.Groups[1].Value));
        monkeys.Add(monkey);
        Console.WriteLine(line);
        Console.WriteLine(monkeys.Last().Id);
    }

    var startingItems = Regex.Match(line, @"^\s+(.+)$");

});

internal sealed class Monkey
{
    public Monkey(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}