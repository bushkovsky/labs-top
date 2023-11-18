namespace Itmo.ObjectOrientedProgramming.Lab2.Components.SSDcomponents;

public class SSD : IComponent
{
    public SSD(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
    public int Memory { get; private set; }
    public int MaxSpeedWork { get; private set; }
    public int Power { get; private set; }
    public ConnectionOption Option { get; private set; }

    public void SetMemory(int memory)
    {
        Memory = memory;
    }

    public void SetMaxSpeedWork(int maxSpeedWork)
    {
        MaxSpeedWork = maxSpeedWork;
    }

    public void SetPower(int power)
    {
        Power = power;
    }

    public void SetConnectionOption(ConnectionOption option)
    {
        Option = option;
    }
}