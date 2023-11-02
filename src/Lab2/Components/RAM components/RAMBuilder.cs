using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.RAMcomponents;

public class RAMBuilder : IRAMBuilder
{
    /*
     *
     * public string Name { get; }
    public int Memory { get; private set; }
    public int Voltage { get; private set; }
    public int JEDEC { get; private set; }
    public string FormFactor { get; private set; } = " ";
    public int DDRVersion { get; private set; }
     */
    private RAM _ram = new RAM(" ", new List<string>());
    public RAMBuilder(string productName)
    {
        Reset(productName);
    }

    public void Reset(string productName)
    {
        _ram = new RAM(productName, _ram.XmpList);
    }

    public void Add(string xmp)
    {
        _ram.Add(xmp);
    }

    public void MemoryBuild(int memory)
    {
        _ram.SetMemory(memory);
    }

    public void VoltageBuild(int voltage)
    {
        _ram.SetVoltage(voltage);
    }

    public void JedecEBuild(int jedec)
    {
        _ram.SetJEDEC(jedec);
    }

    public void FormFactorBuild(string formFactor)
    {
        _ram.SetFormFactor(formFactor);
    }

    public void DDRVersionBuild(int version)
    {
        _ram.SetDDRVersion(version);
    }

    public void Debuild(RAM ram, string newName)
    {
       Reset(newName);
       MemoryBuild(ram.Memory);
       VoltageBuild(ram.Voltage);
       JedecEBuild(ram.JEDEC);
       FormFactorBuild(ram.FormFactor);
       DDRVersionBuild(ram.DDRVersion);
    }

    public RAM GetRAM()
    {
        RAM result = _ram;
        Reset(" ");
        return result;
    }
}