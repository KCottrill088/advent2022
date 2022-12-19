using System.Text.RegularExpressions;

var commands = File.ReadAllLines("/home/kevin/repos/advent2022/day7/Day7/data/commands.example");

Directory fileSystem;
Directory currentDirectory = null;
foreach (var command in commands)
{
    if (Regex.Match(command, @"^\$\s+").Success)
    {
        if (Regex.Match(command, @"^\$\s+cd\s+").Success)
        {
            Console.WriteLine(command);
            var dirName = command[5..];
            var directory = new Directory(dirName);
            Console.WriteLine(dirName);
            if (dirName.Equals("/"))
                fileSystem = directory;
            currentDirectory = directory;
        }
    }
    else
    {
        var fileMatch = Regex.Match(command, @"^(\d+)\s+(\S+)$");
        if (fileMatch.Success)
        {
            var file = new ElfFile(fileMatch.Groups[2].Captures[0].Value, int.Parse(fileMatch.Groups[1].Captures[0].Value));
            Console.WriteLine($"{file.Name} {file.Size}");
            currentDirectory.Files.Add(file);
        }
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
    public IList<Directory> Directories { get; }
    public IList<ElfFile> Files { get; }
}

public record ElfFile(string Name, int Size);
