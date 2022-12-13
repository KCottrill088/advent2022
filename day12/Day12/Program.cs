var heights = File.ReadAllLines("/home/kevin/repos/advent2022/day12/Day12/data/heightmap.example");

foreach (var row in heights)
{
    Console.WriteLine(row);
}

// (var startRow, var startCol) = HeightMap.FindCharacter(heights, 'S');
// Console.WriteLine($"Starting position is : {startRow}, {startCol}");
(var startRow, var startCol) = HeightMap.FindCharacter(heights, 'E');
Console.WriteLine($"Goal position is : {startRow}, {startCol}");

class HeightMap
{
    public static (int, int) FindCharacter(IList<string> map, char searchChar)
    {
        for (var row = 0; row < map.Count; row++)
            for (var col = 0; col < map[row].Length; col++)
                if (map[row][col] == searchChar)
                    return (row, col);
        return default;
    }
}