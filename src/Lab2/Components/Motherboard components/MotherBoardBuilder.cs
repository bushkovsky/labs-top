using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class MotherBoardBuilder : IMotherboardBuilder
{
    public MotherBoardBuilder(string name)
    {
        Name = name;
    }

    private string Name { get; set; }
    private string SocketName { get; set; } = " ";
    private int PcieLineCount { get; set; }
    private int SataCount { get; set; }
    private Chipset ChipsetMotherboard { get; set; } = new Chipset(" ", 0, false);
    private string DDR { get; set; } = " ";
    private int RamCount { get; set; }
    private string FormFactor { get; set; } = " ";
    private BIOS Bios { get; set; } = new BIOS(" ", new List<string>());
    public void SocketNameBuild(string socket)
    {
        SocketName = socket;
    }

    public void PcieLineCountBuild(int count)
    {
        PcieLineCount = count;
    }

    public void SataCountBuild(int count)
    {
        SataCount = count;
    }

    public void ChipsetMotherboardBuild(Chipset chipsetMotherboard)
    {
        ChipsetMotherboard = chipsetMotherboard;
    }

    public void DDRBuild(string ddr)
    {
        DDR = ddr;
    }

    public void RamCountBuild(int count)
    {
        RamCount = count;
    }

    public void FormFactorBuild(string formFactor)
    {
        FormFactor = formFactor;
    }

    public void BIOSBuild(BIOS bios)
    {
        Bios = bios;
    }

    public void Debuild(Motherboard motherboard, string newName)
    {
        SocketNameBuild(motherboard.SocketName);
        PcieLineCountBuild(motherboard.PcieLineCount);
        SataCountBuild(motherboard.SataCount);
        ChipsetMotherboardBuild(motherboard.ChipsetMotherboard);
        DDRBuild(motherboard.DDR);
        RamCountBuild(motherboard.RamCount);
        FormFactorBuild(motherboard.FormFactor);
        BIOSBuild(motherboard.Bios);
    }

    public Motherboard GetMotherboard()
    {
        var result = new Motherboard(Name);
        result.SetBios(Bios);
        result.SetChipsetMotherboard(ChipsetMotherboard);
        result.SetFormFactor(FormFactor);
        result.SetSataCount(SataCount);
        result.SetRamCount(RamCount);
        result.SetSocketName(SocketName);
        result.SetDDR(DDR);
        result.SetPcieLineCount(PcieLineCount);
        return result;
    }
}