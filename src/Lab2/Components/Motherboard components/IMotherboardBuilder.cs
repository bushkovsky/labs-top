namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IMotherboardBuilder
{
    public void Reset(string name);

    public void SocketNameBuild(string socket);

    public void PcieLineCountBuild(int count);

    public void SataCountBuild(int count);

    public void ChipsetMotherboardBuild(Chipset chipsetMotherboard);

    public void DDRBuild(string ddr);

    public void RamCountBuild(int count);

    public void FormFactorBuild(string formFactor);

    public void BIOSBuild(BIOS bios);

    public void Debuild(Motherboard motherboard, string newName);

    public Motherboard GetMotherboard();
}