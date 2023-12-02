using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Interactions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileDelete : ICommand
{
    public FileDelete(string path)
    {
        Path = path;
    }

    public string Path { get; }

    public string? CommandExecute(StatusFileSystem status)
    {
        File.Delete(Path);
        return "Successful delete";
    }
}