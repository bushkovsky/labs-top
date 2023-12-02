using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Interactions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileShow : ICommand
{
    public FileShow(string path)
    {
        Path = path;
    }

    public string Path { get; }

    public string? CommandExecute(StatusFileSystem status)
    {
        return File.ReadAllText(@Path);
    }
}