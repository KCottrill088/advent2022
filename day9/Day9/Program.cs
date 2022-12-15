var moves = File.ReadAllLines("data/moves.dat");
var moveInputs = moves.Select(move => new MoveInput(move[0], int.TryParse(move.Substring(2), out var d) ? d : 0)).ToList();

var rope = new Rope(2);
moveInputs.ForEach(m => rope.Move(m));
Console.WriteLine($"Tail visited {rope.Visited} spaces.");

var longRope = new LongRope();
moveInputs.ForEach(m => longRope.Move(m));
Console.WriteLine($"Tail visited {longRope.Visited} spaces.");

public record MoveInput(char Direction, int Distance);

public record Position(int X, int Y);

// Rope from part 2
public sealed class LongRope
{
    private readonly HashSet<Position> _visited;

    public LongRope()
    {
        Knots = new Position[10];
        _visited = new HashSet<Position>
        {
            new(0, 0)
        };
    }

    public IList<Position> Knots { get; set; }

    public int Visited => _visited.Count;

    public void Move(MoveInput input)
    {
        for (var i = 0; i < input.Distance; i++)
        {
            if (input.Direction == 'U')
            {
                Knots[0] = new Position(Knots[0].X, Knots[0].Y + 1);
                if (Knots[0].Y - 1 > Knots[1].Y)
                    Knots[1] = new Position(Knots[0].X, Knots[0].Y - 1);
                _visited.Add(Knots[9]);
            }
            else if (input.Direction == 'D')
            {
                Knots[0] = new Position(Knots[0].X, Knots[0].Y - 1);
                if (Knots[0].Y + 1 < Knots[1].Y)
                    Knots[1] = new Position(Knots[0].X, Knots[0].Y + 1);
                _visited.Add(Knots[9]);
            }
            else if (input.Direction == 'R')
            {
                Knots[0] = new Position(Knots[0].X + 1, Knots[0].Y);
                if (Knots[0].X - 1 > Knots[1].X)
                    Knots[1] = new Position(Knots[0].X - 1, Knots[0].Y);
                _visited.Add(Knots[9]);
            }
            else if (input.Direction == 'L')
            {
                Knots[0] = new Position(Knots[0].X - 1, Knots[0].Y);
                if (Knots[0].X + 1 < Knots[1].X)
                    Knots[1] = new Position(Knots[0].X + 1, Knots[0].Y);
                _visited.Add(Knots[9]);
            }
        }
    }

    public void MoveKnots()
    {
        for (var i = 2; i < 10; i++)
        {
            if (Knots[i].X - Knots[i - 1].X > 1)
            {
                // Knots[i] = new Position();
            }
        }
    }
}

// Rope from part 1
public sealed class Rope
{
    private readonly HashSet<Position> _visited;

    public Rope(int knots)
    {
        Knots = new Position[knots];
        Knots[0] = new Position(0, 0);
        Knots[1] = new Position(0, 0);
        _visited = new HashSet<Position>
        {
            new(0, 0)
        };
    }

    public Position Head => Knots[0];
    public Position Tail => Knots[1];

    public IList<Position> Knots { get; set; }
    public int Visited => _visited.Count;

    public void Move(MoveInput input)
    {
        for (var i = 0; i < input.Distance; i++)
        {
            if (input.Direction == 'U')
            {
                Knots[0] = new Position(Knots[0].X, Knots[0].Y + 1);
                if (Knots[0].Y - 1 > Knots[1].Y)
                    Knots[1] = new Position(Knots[0].X, Knots[0].Y - 1);
                _visited.Add(Knots[1]);
            }
            else if (input.Direction == 'D')
            {
                Knots[0] = new Position(Knots[0].X, Knots[0].Y - 1);
                if (Knots[0].Y + 1 < Knots[1].Y)
                    Knots[1] = new Position(Knots[0].X, Knots[0].Y + 1);
                _visited.Add(Knots[1]);
            }
            else if (input.Direction == 'R')
            {
                Knots[0] = new Position(Knots[0].X + 1, Knots[0].Y);
                if (Knots[0].X - 1 > Knots[1].X)
                    Knots[1] = new Position(Knots[0].X - 1, Knots[0].Y);
                _visited.Add(Knots[1]);
            }
            else if (input.Direction == 'L')
            {
                Knots[0] = new Position(Knots[0].X - 1, Knots[0].Y);
                if (Knots[0].X + 1 < Knots[1].X)
                    Knots[1] = new Position(Knots[0].X + 1, Knots[0].Y);
                _visited.Add(Knots[1]);
            }
        }
    }
}
