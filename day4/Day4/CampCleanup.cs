var pairs = File.ReadAllLines("data/pairs.dat");

Console.WriteLine(pairs.ToList().Select(x => new Pair(x)).Count(PairInspector.FullyContains));
Console.WriteLine(pairs.ToList().Select(x => new Pair(x)).Count(PairInspector.Contains));

public static class PairInspector
{
    public static bool FullyContains(Pair pair) =>
        (pair.Section1.LowerBound >= pair.Section2.LowerBound)
        && (pair.Section1.UpperBound <= pair.Section2.UpperBound) ||
        (pair.Section2.LowerBound >= pair.Section1.LowerBound
         && pair.Section2.UpperBound <= pair.Section1.UpperBound);

    public static bool Contains(Pair pair) =>
        !(pair.Section1.UpperBound < pair.Section2.LowerBound ||
        pair.Section1.LowerBound > pair.Section2.UpperBound);
}

public record Pair
{
    public Section Section2 { get; set; }
    public Section Section1 { get; set; }

    public Pair(string fileInput)
    {
        var sectionInputs = fileInput.Split(',');
        Section1 = new Section(sectionInputs[0]);
        Section2 = new Section(sectionInputs[1]);
    }

    public record Section
    {
        public int UpperBound { get; set; }
        public int LowerBound { get; set; }
        public Section(string sectionInput)
        {
            var bounds = sectionInput.Split('-');
            LowerBound = int.TryParse(bounds[0], out var lowerBound) ? lowerBound : 0;
            UpperBound = int.TryParse(bounds[1], out var upperBound) ? upperBound : 0;
        }
    }
}