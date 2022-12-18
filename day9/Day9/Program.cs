var moves = File.ReadAllLines("data/moves.dat");
var moveInputs = moves.Select(move => new MoveInput(move[0], int.TryParse(move.Substring(2), out var d) ? d : 0)).ToList();

var rope = new Rope(2);
moveInputs.ForEach(m => rope.Move(m));
Console.WriteLine($"Tail visited {rope.Visited} spaces.");

var longRope = new Rope(10);
moveInputs.ForEach(m => longRope.Move(m));
Console.WriteLine($"Tail of long rope visited {longRope.Visited} spaces.");

public record MoveInput(char Direction, int Distance);

public record Position(int X, int Y);

public sealed class Rope
{
    private readonly HashSet<Position> _visited;

    public Rope(int knots)
    {
        Knots = new Position[knots];
        for (var i = 0; i < knots; i++)
        {
            Knots[i] = new Position(0, 0);
        }
        _visited = new HashSet<Position>
        {
            new(0, 0)
        };
    }

    public Position Head => Knots[0];
    public Position Tail => Knots[1];

    private IList<Position> Knots { get; set; }
    public int Visited => _visited.Count;

    public void Move(MoveInput input)
    {
        for (var i = 0; i < input.Distance; i++)
        {
            Knots[0] = input.Direction switch
            {
                'U' => new Position(Knots[0].X, Knots[0].Y + 1),
                'D' => new Position(Knots[0].X, Knots[0].Y - 1),
                'R' => new Position(Knots[0].X + 1, Knots[0].Y),
                'L' => new Position(Knots[0].X - 1, Knots[0].Y),
                _ => Knots[0]
            };

            for (var j = 1; j < Knots.Count; j++)
            {
                if (Knots[j - 1].Y - 1 > Knots[j].Y)
                    Knots[j] = new Position(Knots[j-1].X, Knots[j-1].Y - 1);
                if (Knots[j - 1].Y + 1 < Knots[j].Y)
                    Knots[j] = new Position(Knots[j-1].X, Knots[j-1].Y + 1);
                if (Knots[j - 1].X - 1 > Knots[j].X)
                    Knots[j] = new Position(Knots[j-1].X - 1, Knots[j-1].Y);
                if (Knots[j - 1].X + 1 < Knots[j].X)
                    Knots[j] = new Position(Knots[j-1].X + 1, Knots[j-1].Y);
            }
            _visited.Add(Knots.Last());
        }
    }
}
