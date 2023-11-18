namespace Itmo.ObjectOrientedProgramming.Lab2.Components.PowerSupplycomponents;

public class PowerSupply : IComponent
{
    public PowerSupply(string productName)
    {
        Name = productName;
    }

    public string Name { get; }
    public int LoadPower { get; private set; }

    public void SetLoadPower(int power)
    {
        LoadPower = power;
    }
}