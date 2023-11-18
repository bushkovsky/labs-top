namespace Itmo.ObjectOrientedProgramming.Lab2.Components.RAMcomponents;

public interface IRAMBuilder
{
    public void Reset(string productName);

    public void Add(string xmp);

    public void MemoryBuild(int memory);

    public void VoltageBuild(int voltage);

    public void JedecEBuild(int jedec);

    public void FormFactorBuild(string formFactor);

    public void DDRVersionBuild(int version);

    public void Debuild(RAM ram, string newName);

    public RAM GetRAM();
}