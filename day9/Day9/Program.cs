var moves = File.ReadAllLines("/home/kevin/repos/advent2022/day9/Day9/data/moves.larger");
var moveInputs = moves.Select(move => new MoveInput(move[0], int.TryParse(move.Substring(2), out var d) ? d : 0)).ToList();

// var rope = new Rope(2);
// moveInputs.ForEach(m => rope.Move(m));
// Console.WriteLine($"Tail visited {rope.Visited} spaces.");

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

    public IList<Position> Knots { get; set; }
    public int Visited => _visited.Count;

    public void Move(MoveInput input)
    {
        for (var i = 0; i < input.Distance; i++)
        {
            if (input.Direction == 'U')
            {
                Knots[0] = new Position(Knots[0].X, Knots[0].Y + 1);
            }
            else if (input.Direction == 'D')
            {
                Knots[0] = new Position(Knots[0].X, Knots[0].Y - 1);
            }
            else if (input.Direction == 'R')
            {
                Knots[0] = new Position(Knots[0].X + 1, Knots[0].Y);
            }
            else if (input.Direction == 'L')
            {
                Knots[0] = new Position(Knots[0].X - 1, Knots[0].Y);
            }

            var j = 1;
            while (j < Knots.Count && Knots[j - 1].Y - 1 > Knots[j].Y)
            {
                Knots[j] = new Position(Knots[j-1].X, Knots[j-1].Y - 1);
                j++;
            }

            while (j < Knots.Count && Knots[j - 1].Y + 1 < Knots[j].Y)
            {
                Knots[j] = new Position(Knots[j-1].X, Knots[j-1].Y + 1);
                j++;
            }

            while (j < Knots.Count && Knots[j - 1].X - 1 > Knots[j].X)
            {
                Knots[j] = new Position(Knots[j-1].X - 1, Knots[j-1].Y);
                j++;
            }
            
            while (j < Knots.Count && Knots[j - 1].X + 1 < Knots[j].X)
            {
                Knots[j] = new Position(Knots[j-1].X + 1, Knots[j-1].Y);
                j++;
            }

            _visited.Add(Knots.Last());
        }
        // Visualization:
        var minX = 0;
        var maxX = 0;
        var minY = 0;
        var maxY = 0;
        foreach (var k in Knots)
        {
            maxX = Math.Max(maxX, k.X);
            minX = Math.Min(minX, k.X);
            maxY = Math.Max(maxY, k.Y);
            minY = Math.Min(minY, k.Y);
        }

        maxX++;
        maxX++;
        minX--;
        maxY++;
        minY--;
        minY--;
        for (var y = maxY; y > minY; y--)
        {
            for (var x = minX; x < maxX; x++)
            {
                var sym = ".";
                for (var z = 0; z < Knots.Count; z++)
                {
                    if (Knots[z].X == x && Knots[z].Y == y)
                    {
                        sym = z.ToString();
                        break;
                    }
                }
                Console.Write(sym);
            }
            Console.WriteLine();
        }
    }
}
