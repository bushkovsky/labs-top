using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Repositories;

public class MarkRepository
{
    public MarkRepository()
    {
        CommandMarks = new Dictionary<string, Marks>();
        Add("{-d", Marks.D);
        Add("[-m", Marks.M);
        Add("{-m", Marks.M);
    }

    public Dictionary<string, Marks> CommandMarks { get; }

    public void Add(string key, Marks mode)
    {
        CommandMarks.Add(key, mode);
    }

    public Marks GetMark(string key)
    {
        return CommandMarks[key];
    }
}