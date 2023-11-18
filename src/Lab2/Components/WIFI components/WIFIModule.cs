namespace Itmo.ObjectOrientedProgramming.Lab2.Components.WIFIcomponents;

public class WIFIModule : IComponent
{
    public WIFIModule(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public int Version { get; private set; }
    public bool Bluetooth { get; private set; }
    public int PCIE { get; private set; }
    public int Power { get; private set; }

    public void SetVersion(int version)
    {
        Version = version;
    }

    public void SetBluetooth(bool bluetooth)
    {
        Bluetooth = bluetooth;
    }

    public void SetPCIE(int pcie)
    {
        PCIE = pcie;
    }

    public void SetPower(int power)
    {
        Power = power;
    }
}