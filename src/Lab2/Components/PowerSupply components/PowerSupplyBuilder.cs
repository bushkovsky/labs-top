namespace Itmo.ObjectOrientedProgramming.Lab2.Components.PowerSupplycomponents;

public class PowerSupplyBuilder : IPowerSupplyBuilder
{
    private PowerSupply _powerSupply = new PowerSupply(" ");

    public PowerSupplyBuilder(string name)
    {
        Reset(name);
    }

    public void Reset(string name)
    {
        _powerSupply = new PowerSupply(name);
    }

    public void LoadPowerBuild(int loadPower)
    {
        _powerSupply.SetLoadPower(loadPower);
    }

    public void Debuild(PowerSupply powerSupply, string newName)
    {
        Reset(newName);
        LoadPowerBuild(powerSupply.LoadPower);
    }

    public PowerSupply GetPowerSupply()
    {
        PowerSupply result = _powerSupply;
        Reset(" ");
        return result;
    }
}