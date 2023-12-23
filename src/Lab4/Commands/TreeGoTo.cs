using Itmo.ObjectOrientedProgramming.Lab4.Interactions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeGoTo : ICommand
{
    public TreeGoTo(string path)
    {
        Path = path;
    }

    public string Path { get; }
    public string? CommandExecute(StatusFileSystem status)
    {
        return Path;
    }
}