namespace Itmo.ObjectOrientedProgramming.Lab2.Components.SSDcomponents;

public class SSDBuilder : ISSDBuilder
{
    private SSD _ssd = new SSD(" ");

    public SSDBuilder(string productName)
    {
        Reset(productName);
    }

    public void Reset(string productName)
    {
        _ssd = new SSD(productName);
    }

    public void MemoryBuild(int memory)
    {
        _ssd.SetMemory(memory);
    }

    public void MaxSpeedWorkBuild(int maxSpeed)
    {
        _ssd.SetMaxSpeedWork(maxSpeed);
    }

    public void PowerBuild(int power)
    {
        _ssd.SetPower(power);
    }

    public void ConnectionOptionBuild(ConnectionOption optionConnect)
    {
        _ssd.SetConnectionOption(optionConnect);
    }

    public void Debuild(SSD ssd, string newName)
    {
        Reset(newName);
        MemoryBuild(ssd.Memory);
        MaxSpeedWorkBuild(ssd.MaxSpeedWork);
        PowerBuild(ssd.Power);
        ConnectionOptionBuild(ssd.Option);
    }

    public SSD GetSSD()
    {
        SSD result = _ssd;
        Reset(" ");
        return result;
    }
}