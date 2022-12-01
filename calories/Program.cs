using System.Numerics;

BigInteger sum= 0;

List<BigInteger> calories = new List<BigInteger>();

foreach (var line in File.ReadLines(@"/home/kevin/repos/advent2022/data/calories.dat"))
{
    if (string.IsNullOrWhiteSpace(line))
    {
        calories.Add(sum);
        sum = 0;
    }
    else if (BigInteger.TryParse(line, out var number))
    {
        sum += number;
    }
}
calories.Add(sum);

Console.WriteLine(calories.OrderByDescending(x => x).ToList().GetRange(0, 3).Sum(x => (long)x));
