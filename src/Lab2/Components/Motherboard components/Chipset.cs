namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class Chipset : IComponent
{
    public Chipset(string name, int frequency, bool xmp)
    {
        Name = name;
        Frequency = frequency;
        XmpSupport = xmp;
    }

    public string Name { get; }
    public int Frequency { get; }
    public bool XmpSupport { get; }
}