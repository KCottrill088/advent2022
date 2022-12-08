using System.Security.Principal;
using System.Text.RegularExpressions;

var commands = File.ReadAllLines("data/commands.example");

var fileSystem = new Directory("/");
foreach (var command in commands)
{
    if (Regex.Match(command, @"^\$\s+").Success)
    {
        var result = Interpreter.Dispatch(command);
            if (result is not null)
                Console.WriteLine(result);
    }
}

public sealed class Directory
{
    public Directory(string name)
    {
        Name = name;
        Directories = new List<Directory>();
        Files = new List<ElfFile>();
    }

    public string Name { get; }
    public IEnumerable<Directory> Directories { get; }
    public IEnumerable<ElfFile> Files { get; }
}

public record ElfFile(string Name, int Size);

public sealed class Interpreter
{
    private string _wd = String.Empty;
    public static string? Dispatch(string command)
    {
        if (Regex.Match(command, @"^\$\s+cd\s+").Success)
            return command;
        return default;
    }
}
