using MoreLinq;

var items = File.ReadAllLines("data/items.dat");

Console.WriteLine(items.Select(x => new Rucksack(x)).Select(x => Rucksack.Priority(x.ItemInBoth())).Sum());

var badges = new List<char>();
foreach (var group in items.Batch(3))
{
    var firstRucksackItems = new HashSet<char>();
    group.First().ToList().ForEach(x => firstRucksackItems.Add(x));
    var candidates = new HashSet<char>();
    foreach (var c in group.ToArray()[1])
    {
        if (firstRucksackItems.Contains(c))
            candidates.Add(c);
    }

    foreach (var c in group.Last())
    {
        if (candidates.Contains(c))
        {
            badges.Add(c);
            break;
        }
    }
}

Console.WriteLine(badges.Select(x => Rucksack.Priority(x)).Sum());

public sealed class Rucksack
{
    private readonly IEnumerable<char> _compartment1;
    private readonly IEnumerable<char> _compartment2;

    public Rucksack(string items)
    {
        _compartment1 = items[..(items.Length / 2)];
        _compartment2 = items[(items.Length / 2)..];
    }

    public IEnumerable<char> Compartment1 => _compartment1;

    public IEnumerable<char> Compartment2 => _compartment2;

    public char ItemInBoth()
    {
        var compartment1Items = new HashSet<char>();
        Compartment1.ToList().ForEach(x => compartment1Items.Add(x));
        return (from item in Compartment2 where compartment1Items.Contains(item) select item ).FirstOrDefault();
    }

    public static int Priority(char item) =>
        char.IsUpper(item)
            ? item - 'A' + 27
            : item - 'a' + 1;
}
