namespace Itmo.ObjectOrientedProgramming.Lab2.Components.XMPProfilecomponents;

public class XMPProfile : IComponent
{
    public XMPProfile(string productName)
    {
        Name = productName;
    }

    public string Name { get; }
    public int Timing { get; private set; }
    public int Voltage { get; private set; }
    public int Frequency { get; private set; }

    public void SetTiming(int time)
    {
        Timing = time;
    }

    public void SetVoltage(int voltage)
    {
        Voltage = voltage;
    }

    public void SetFrequency(int frequency)
    {
        Frequency = frequency;
    }
}