using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.GraficCardcomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.HDDcomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.PowerSupplycomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.RAMcomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.SSDcomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.WIFIcomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.XMPProfilecomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.СomputerСasecomponents;
namespace Itmo.ObjectOrientedProgramming.Lab2.Components.PersonalComputer;

public class Computer
{
    public Computer(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public ComputerCase Case { get; private set; } = new ComputerCase(" ");
    public CoolingSystem PcCoolingSystem { get; private set; } = new CoolingSystem(" ", new List<string>());
    public CPU PcCpu { get; private set; } = new CPU(" ");
    public GraficCard? PcGraficCard { get; private set; }
    public HDD? PcHDD { get; private set; }
    public Motherboard PcMotherboard { get; private set; } = new Motherboard(" ");
    public PowerSupply PcPowerSupply { get; private set; } = new PowerSupply(" ");
    public RAM PcRam { get; private set; } = new RAM(" ", new List<string>());
    public SSD? PcSSD { get; private set; }
    public WIFIModule? PcWifiModule { get; private set; }
    public XMPProfile? PcXmpProfile { get; private set; }

    public void SetComputerCase(ComputerCase computerCase)
    {
        Case = computerCase;
    }

    public void SetCoolingSystem(CoolingSystem coolingSystem)
    {
        PcCoolingSystem = coolingSystem;
    }

    public void SetCPU(CPU cpu)
    {
        PcCpu = cpu;
    }

    public void SetGraficCard(GraficCard graficCard)
    {
        PcGraficCard = graficCard;
    }

    public void SetHDD(HDD hdd)
    {
        PcHDD = hdd;
    }

    public void SetMotherboard(Motherboard motherboard)
    {
        PcMotherboard = motherboard;
    }

    public void SetPowerSupply(PowerSupply powerSupply)
    {
        PcPowerSupply = powerSupply;
    }

    public void SetRAM(RAM ram)
    {
        PcRam = ram;
    }

    public void SetSSD(SSD ssd)
    {
        PcSSD = ssd;
    }

    public void SetWIFIModule(WIFIModule wifiModule)
    {
        PcWifiModule = wifiModule;
    }

    public void SetXMPProfile(XMPProfile xmpProfile)
    {
        PcXmpProfile = xmpProfile;
    }
}