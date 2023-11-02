namespace Itmo.ObjectOrientedProgramming.Lab2.Components.HDDcomponents;

public class HDDBuilder : IHDDBuilder
{
    /*
     *    public string Name { get; }
    public int Memory { get; }
    public int RotationSpeed { get; }
    public int Power { get; }
     */
    private HDD _hdd = new HDD(" ");

    public HDDBuilder(string productName)
    {
        Reset(productName);
    }

    public void Reset(string productName)
    {
        _hdd = new HDD(productName);
    }

    public void MemoryBuild(int memory)
    {
        _hdd.SetMemory(memory);
    }

    public void RotationSpeedBuild(int rotationSpeed)
    {
        _hdd.SetRotationSpeed(rotationSpeed);
    }

    public void PowerBuild(int power)
    {
        _hdd.SetPower(power);
    }

    public void Debuild(HDD hdd, string newName)
    {
        Reset(newName);
        MemoryBuild(hdd.Memory);
        RotationSpeedBuild(hdd.RotationSpeed);
        PowerBuild(hdd.Power);
    }

    public HDD GetHdd()
    {
        HDD result = _hdd;
        Reset(" ");
        return result;
    }
}