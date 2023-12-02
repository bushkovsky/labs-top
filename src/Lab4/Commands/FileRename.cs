using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Interactions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRename : ICommand
{
    public FileRename(string path, string name)
    {
        Path = path;
        Name = name;
    }

    public string Path { get; }
    public string Name { get; }

    public string? CommandExecute(StatusFileSystem status)
    {
        bool flag = false;
        string newPath = string.Empty;

        for (int i = Path.Length - 1; i > -1; i--)
        {
            if (Path[i] == @"\".ToCharArray()[0])
            {
                flag = true;
            }

            if (flag)
            {
                newPath = newPath.Insert(0, Path[i].ToString());
            }
        }

        newPath += Name;
        using (File.Create(newPath))
        {
            File.Delete(Path);
        }

        return "sccesful rename";
    }
}