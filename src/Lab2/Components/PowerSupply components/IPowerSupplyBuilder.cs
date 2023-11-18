namespace Itmo.ObjectOrientedProgramming.Lab2.Components.PowerSupplycomponents;

public interface IPowerSupplyBuilder
{
    public void Reset(string name);

    public void LoadPowerBuild(int loadPower);

    public void Debuild(PowerSupply powerSupply, string newName);

    public PowerSupply GetPowerSupply();
}