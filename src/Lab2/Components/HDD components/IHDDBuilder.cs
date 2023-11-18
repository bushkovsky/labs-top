namespace Itmo.ObjectOrientedProgramming.Lab2.Components.HDDcomponents;

public interface IHDDBuilder
{
    public void Reset(string productName);

    public void MemoryBuild(int memory);

    public void RotationSpeedBuild(int rotationSpeed);

    public void PowerBuild(int power);

    public void Debuild(HDD hdd, string newName);

    public HDD GetHdd();
}