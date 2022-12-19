using System.Text.RegularExpressions;

var input = File.ReadAllLines("/home/kevin/repos/advent2022/day11/Day11/data/monkeys.example");
input.ToList().ForEach(line =>
{
    var monkeyLine = Regex.Match(line, @"^Monkey\s+(\d+):"); 
    if (monkeyLine.Success)
    {
        Console.WriteLine(line);
        Console.WriteLine(monkeyLine.Groups[1]);
    }
});