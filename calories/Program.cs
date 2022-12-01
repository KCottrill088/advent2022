using System.Numerics;

BigInteger sum= 0;
BigInteger max = 0;

foreach (var line in File.ReadLines(@"/home/kevin/repos/advent2022/data/calories.example"))
{
    if (string.IsNullOrWhiteSpace(line))
    {
        sum = 0;
    }
    else if (BigInteger.TryParse(line, out var number))
    {
        sum += number;
    }
    max = BigInteger.Max(sum, max);
}
Console.WriteLine($"Max {max}");
