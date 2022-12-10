var moves = File.ReadAllLines("data/moves.example");

var position = new Pair(0, 0);
foreach (var move in moves)
{
    var direction = move[0];
    var distance = int.TryParse(move.Substring(2), out var d) ? d : 0;
    Console.WriteLine($"{direction}\t{distance}");
}

record Pair(int X, int Y);
