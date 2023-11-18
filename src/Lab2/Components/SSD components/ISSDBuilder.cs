namespace Itmo.ObjectOrientedProgramming.Lab2.Components.SSDcomponents;

public interface ISSDBuilder
{
    public void Reset(string productName);

    public void MemoryBuild(int memory);

    public void MaxSpeedWorkBuild(int maxSpeed);

    public void PowerBuild(int power);

    public void ConnectionOptionBuild(ConnectionOption optionConnect);

    public void Debuild(SSD ssd, string newName);

    public SSD GetSSD();
}