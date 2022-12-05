var moves = File.ReadAllLines("data/strategy.dat");

var sum = 0;
foreach(var move in moves) sum += Rochambeau.AssumedScore(move);
Console.WriteLine(sum);
Console.WriteLine(moves.Select(x => Rochambeau.AssumedScore(x)).Sum());

sum = 0;
foreach(var move in moves) sum += Rochambeau.SpecifiedScore(move);
Console.WriteLine(sum);
Console.WriteLine(moves.Select(x => Rochambeau.SpecifiedScore(x)).Sum());

public static class Rochambeau
{
    // A, B, C : Rock, Paper, Scissors
    // X, Y, Z : Rock, Paper, Scissors : 1, 2, 3
    // Win, Lose, Draw : 6, 3, 0
    private static readonly Dictionary<string, int> AssumedResults = new Dictionary<string, int>
    {
        { "A X", 4 },
        { "B X", 1 },
        { "C X", 7 },
        { "A Y", 8 },
        { "B Y", 5 },
        { "C Y", 2 },
        { "A Z", 3 },
        { "B Z", 9 },
        { "C Z", 6 }
    };
    public static int AssumedScore(string strategy)
    {
        return AssumedResults[strategy];
    }

    // X, Y, Z : Lose, Draw, Win
    private static readonly Dictionary<string, int> SpecifiedResults = new Dictionary<string, int>
    {
        { "A X", 3 },
        { "B X", 1 },
        { "C X", 2 },
        { "A Y", 4 },
        { "B Y", 5 },
        { "C Y", 6 },
        { "A Z", 8 },
        { "B Z", 9 },
        { "C Z", 7 }
    };
    public static int SpecifiedScore(string strategy)
    {
        return SpecifiedResults[strategy];
    }
}
