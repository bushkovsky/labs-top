namespace Itmo.ObjectOrientedProgramming.Lab2.Components.HDDcomponents;

public class HDD : IComponent
{
    public HDD(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public int Memory { get; private set; }
    public int RotationSpeed { get; private set; }
    public int Power { get; private set; }

    public void SetMemory(int memory)
    {
        Memory = memory;
    }

    public void SetRotationSpeed(int rotationSpeed)
    {
        RotationSpeed = rotationSpeed;
    }

    public void SetPower(int power)
    {
        Power = power;
    }
}