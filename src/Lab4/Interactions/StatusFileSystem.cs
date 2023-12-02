namespace Itmo.ObjectOrientedProgramming.Lab4.Interactions;

public class StatusFileSystem
{
    public StatusFileSystem(string? path)
    {
        Path = path;
    }

    public string? Path { get; private set; }

    public void SetNew(string? path)
    {
        Path = path;
    }
}