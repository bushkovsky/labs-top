using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class Motherboard : IComponent
{
    public Motherboard(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public string SocketName { get; private set; } = " ";
    public int PcieLineCount { get; private set; }
    public int SataCount { get; private set; }
    public Chipset ChipsetMotherboard { get; private set; } = new Chipset(" ", 0, false);
    public string DDR { get; private set; } = " ";
    public int RamCount { get; private set; }
    public string FormFactor { get; private set; } = " ";
    public BIOS Bios { get; private set; } = new BIOS(" ", new List<string>());

    public void SetSocketName(string socket)
    {
        SocketName = socket;
    }

    public void SetPcieLineCount(int count)
    {
        PcieLineCount = count;
    }

    public void SetSataCount(int count)
    {
        SataCount = count;
    }

    public void SetChipsetMotherboard(Chipset chipset)
    {
        ChipsetMotherboard = chipset;
    }

    public void SetDDR(string ddr)
    {
        DDR = ddr;
    }

    public void SetRamCount(int ramCount)
    {
        RamCount = ramCount;
    }

    public void SetFormFactor(string formFactor)
    {
        FormFactor = formFactor;
    }

    public void SetBios(BIOS bios)
    {
        Bios = bios;
    }
}