using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Interactions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileCopy : ICommand
{
    public FileCopy(string sourcePath, string destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public string SourcePath { get; }
    public string DestinationPath { get; }

    public string? CommandExecute(StatusFileSystem status)
    {
        File.Copy(SourcePath, DestinationPath);
        return "Successful copying";
    }
}