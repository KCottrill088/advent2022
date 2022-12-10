var instructions = File.ReadAllLines("data/instructions.dat");

var cpu = new Cpu();
foreach (var instruction in instructions)
{
    cpu.Execute(instruction);
}
Console.WriteLine($"Total Signal Strength: {cpu.TotalSignalStrength}");

internal sealed class Cpu
{
    private Crt crt { get; set; } = new Crt();
    private int X { get; set; } = 1;
    private int Cycle { get; set; }
    public int TotalSignalStrength { get; private set; }

    public void Execute(string instruction)
    {
        TickClock(crt);
        var command = instruction[..4];
        if ((command == "addx") && (int.TryParse(instruction[5..], out var magnitude)))
        {
            TickClock(crt);
            X += magnitude;
        }
    }

    private void TickClock(Crt crt)
    {
        Cycle += 1;
        CheckSignalStrength();
        crt.Refresh(Cycle, X);
    }

    private void CheckSignalStrength()
    {
        if ((Cycle - 20) % 40 == 0) TotalSignalStrength += Cycle * X;        
    }
}

internal sealed class Crt
{
    private string ScanLine { get; set; } = "";

    public void Refresh(int cycle, int x)
    {
        var pos = cycle  % 40 - 1;
        if (pos == -1) pos = 39;
        if ((x >= pos - 1) && (x <= pos + 1))
            ScanLine += "#";
        else
            ScanLine += ".";
        if (pos == 39)
        {
            Console.WriteLine(ScanLine);
            ScanLine = "";
        }
    }
}