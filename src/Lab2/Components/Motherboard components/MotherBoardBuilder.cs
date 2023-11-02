namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class MotherBoardBuilder : IMotherboardBuilder
{
    /*
     * public string Name { get; }
    public string SocketName { get; private set; } = " ";
    public int PcieLineCount { get; private set; }
    public int SataCount { get; private set; }
    public Chipset ChipsetMotherboard { get; private set; } = new Chipset(" ", 0, false);
    public string DDR { get; private set; } = " ";
    public int RamCount { get; private set; }
    public string FormFactor { get; private set; } = " ";
    public BIOS Bios { get; private set; } = new BIOS();
     */

    private Motherboard _motherboard = new Motherboard(" ");

    public MotherBoardBuilder(string name)
    {
        Reset(name);
    }

    public void Reset(string name)
    {
        _motherboard = new Motherboard(name);
    }

    public void SocketNameBuild(string socket)
    {
        _motherboard.SetSocketName(socket);
    }

    public void PcieLineCountBuild(int count)
    {
        _motherboard.SetPcieLineCount(count);
    }

    public void SataCountBuild(int count)
    {
        _motherboard.SetSataCount(count);
    }

    public void ChipsetMotherboardBuild(Chipset chipsetMotherboard)
    {
        _motherboard.SetChipsetMotherboard(chipsetMotherboard);
    }

    public void DDRBuild(string ddr)
    {
        _motherboard.SetDDR(ddr);
    }

    public void RamCountBuild(int count)
    {
        _motherboard.SetRamCount(count);
    }

    public void FormFactorBuild(string formFactor)
    {
        _motherboard.SetFormFactor(formFactor);
    }

    public void BIOSBuild(BIOS bios)
    {
        _motherboard.SetBios(bios);
    }

    public void Debuild(Motherboard motherboard, string newName)
    {
        Reset(newName);
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
        Motherboard result = _motherboard;
        Reset(" ");
        return result;
    }
}