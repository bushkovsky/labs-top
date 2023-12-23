using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Repositories;

public class ModeRepository
{
    public ModeRepository()
    {
        CommandModes = new Dictionary<string, Modes>();
        Add("local]", Modes.Local);
        Add("console}", Modes.Console);
    }

    public Dictionary<string, Modes> CommandModes { get; }

    public void Add(string key, Modes mode)
    {
        CommandModes.Add(key, mode);
    }

    public Modes GetMode(string key)
    {
        return CommandModes[key];
    }
}
