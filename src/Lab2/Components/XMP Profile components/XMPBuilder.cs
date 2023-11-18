namespace Itmo.ObjectOrientedProgramming.Lab2.Components.XMPProfilecomponents;

public class XMPBuilder
{
    private XMPProfile _xmp = new XMPProfile(" ");

    public XMPBuilder(string productName)
    {
        Reset(productName);
    }

    public void Reset(string productName)
    {
        _xmp = new XMPProfile(productName);
    }

    public void TimeBuild(int time)
    {
        _xmp.SetTiming(time);
    }

    public void VoltageBuild(int voltage)
    {
        _xmp.SetVoltage(voltage);
    }

    public void FrequencyBuild(int frequency)
    {
        _xmp.SetFrequency(frequency);
    }

    public void Debuild(XMPProfile xmp, string newName)
    {
        Reset(newName);
        TimeBuild(xmp.Timing);
        VoltageBuild(xmp.Voltage);
        FrequencyBuild(xmp.Frequency);
    }

    public XMPProfile GetXmpProfile()
    {
        XMPProfile result = _xmp;
        Reset(" ");
        return result;
    }
}