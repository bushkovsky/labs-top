using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.RAMcomponents;

public class RAM : IComponent
{
    public RAM(string name, IList<string> xmpList)
    {
        Name = name;
        XmpList = xmpList;
    }

    public string Name { get; }
    public int Memory { get; private set; }
    public int Voltage { get; private set; }
    public int JEDEC { get; private set; }
    public string FormFactor { get; private set; } = " ";
    public int DDRVersion { get; private set; }
    public IList<string> XmpList { get; private set; }

    public void Add(string xmp)
    {
        XmpList.Add(xmp);
    }

    public void SetMemory(int memory)
    {
        Memory = memory;
    }

    public void SetVoltage(int voltage)
    {
        Voltage = voltage;
    }

    public void SetJEDEC(int jedec)
    {
        JEDEC = jedec;
    }

    public void SetDDRVersion(int version)
    {
        DDRVersion = version;
    }

    public void SetFormFactor(string form)
    {
        FormFactor = form;
    }
}