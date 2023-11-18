using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class BIOS : IComponent
{
    public BIOS(string name, IList<string> cpus)
    {
        Name = name;
        SupportedProcessors = cpus;
    }

    public string Name { get; }
    public string Type { get; private set; } = " ";
    public int Version { get; private set; }
    public IList<string> SupportedProcessors { get; private set; }

    public void SetType(string type)
    {
        Type = type;
    }

    public void SetVersion(int version)
    {
        Version = version;
    }

    public void Add(string cpu)
    {
        SupportedProcessors.Add(cpu);
    }
}