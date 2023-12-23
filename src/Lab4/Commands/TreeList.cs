using Itmo.ObjectOrientedProgramming.Lab4.Interactions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeList : ICommand
{
    public TreeList(int depth)
    {
        Depth = depth;
    }

    public int Depth { get; }

    public string? CommandExecute(StatusFileSystem status)
    {
        int currentDepth = Depth;
        string newPath = string.Empty;

        if (status.Path != null)
        {
            for (int i = status.Path.Length - 1; i > -1; i--)
            {
                if (status.Path[i] == @"\".ToCharArray()[0])
                {
                    currentDepth--;
                }

                if (currentDepth == 0)
                {
                    newPath = newPath.Insert(0, status.Path[i].ToString());
                }
            }
        }

        status.SetNew(newPath);
        return "Succefull newPath";
    }
}