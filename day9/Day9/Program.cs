var moves = File.ReadAllLines("data/moves.example");
var moveInputs = moves.Select(move => new MoveInput(move[0], int.TryParse(move.Substring(2), out var d) ? d : 0)).ToList();

moveInputs.ForEach(m => Console.WriteLine($"{m.direction}\t{m.distance}"));

var position = new Position(0, 0);

public record MoveInput(char direction, int distance);

public record Position(int X, int Y);

public sealed class Rope
{
    public Rope()
    {
        Head = new Position(0, 0);
        Tail = new Position(0, 0);
    }
    public Position Head { get; set; }
    public Position Tail { get; set; }

    public void Move(MoveInput input)
    {
        
    }
}
