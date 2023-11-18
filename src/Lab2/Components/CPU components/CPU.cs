namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class CPU : IComponent
{
    public CPU(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public int CoreFrequency { get; private set; }
    public int CountCore { get; private set; }
    public string Socket { get; private set; } = " ";
    public bool GraficModification { get; private set; }
    public int MemoryFrequency { get; private set; }
    public int TDP { get; private set; }
    public int Power { get; private set; }

    public void SetCoreFrequency(int frequency)
    {
        CoreFrequency = frequency;
    }

    public void SetCountCore(int count)
    {
        CountCore = count;
    }

    public void SetSocket(string socket)
    {
        Socket = socket;
    }

    public void SetGraficModification(bool graficModification)
    {
        GraficModification = graficModification;
    }

    public void SetMemoryFrequency(int frequency)
    {
        MemoryFrequency = frequency;
    }

    public void SetTDP(int tdp)
    {
        TDP = tdp;
    }

    public void SetPower(int power)
    {
        Power = power;
    }
}