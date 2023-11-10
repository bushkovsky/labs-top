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

public class ComputerBuilder
{
    public ComputerBuilder(string name)
    {
        Name = name;
    }

    public CoolingSystem ComponentCoolingSystem { get; private set; } = new CoolingSystem(" ", new List<string>());
    public CPU ComponentCPU { get; private set; } = new CPU(" ");
    public GraficCard? ComponentGraficCard { get; private set; }
    public HDD? ComponentHdd { get; private set; }
    public Motherboard ComponentMotherboard { get; private set; } = new Motherboard(" ");
    public PowerSupply ComponentPowerSupply { get; private set; } = new PowerSupply(" ");
    public RAM ComponentRam { get; private set; } = new RAM(" ", new List<string>());
    public SSD? ComponentSSD { get; private set; }
    public WIFIModule? ComponentWifiModule { get; private set; }
    public XMPProfile? ComponentXmpProfile { get; private set; }
    public ComputerCase ComponentComputerCase { get; private set; } = new ComputerCase(" ");
    public string Name { get; private set; } = " ";

    public void ComputerCaseBuild(ComputerCase computerCase)
    {
        var builder = new ComputerCaseBuilder(computerCase.Name);
        builder.GraficCardWidthBuild(computerCase.GraficCardWidth);
        builder.GraficCardLength(computerCase.GraficCardLength);
        builder.FormFactorBuild(computerCase.FormFactor);
        builder.WidthBuild(computerCase.Width);
        builder.LengthBuild(computerCase.Length);
        builder.HeightBuild(computerCase.Height);
        ComponentComputerCase = builder.GetComputerCase();
    }

    public string CoolingSystemBuild(CoolingSystem coolingSystem)
    {
        var builder = new CoolingSystemBuilder(coolingSystem.Name, coolingSystem.Sockets);
        builder.TDPBuild(coolingSystem.TDP);
        builder.SizeBuild(coolingSystem.Size);
        ComponentCoolingSystem = builder.GetCoolingSystem();

        if (!ComponentCoolingSystem.Sockets.Contains(ComponentCPU.Socket))
        {
            return "Socket of cooling system not the same socket of cpu";
        }

        if (ComponentCoolingSystem.Size > ComponentComputerCase.Width)
        {
            return "Size of cooling system bigger then width of case";
        }

        if (ComponentCoolingSystem.TDP < ComponentCPU.TDP)
        {
            return "Success, but disclaimer of warranty obligations";
        }

        return "Success";
    }

    public string CPUBuild(CPU cpu)
    {
        var builder = new CPUBuilder(cpu.Name);
        builder.CoreFrequencyBuild(cpu.CoreFrequency);
        builder.CountCoreBuild(cpu.CountCore);
        builder.SocketBuild(cpu.Socket);
        builder.GraficModificationBuild(cpu.GraficModification);
        builder.MemoryFrequencyBuild(cpu.MemoryFrequency);
        builder.TDPBuild(cpu.TDP);
        builder.PowerBuild(cpu.Power);
        ComponentCPU = builder.GetCPU();
        if (ComponentMotherboard.SocketName != ComponentCPU.Socket)
        {
            return "Sockets of motherboard and cpu not the same";
        }

        if (!ComponentMotherboard.Bios.SupportedProcessors.Contains(ComponentCPU.Name))
        {
            return "Bios can't use with this CPU";
        }

        if (ComponentXmpProfile is not null && !(ComponentCPU.MemoryFrequency == ComponentXmpProfile.Frequency))
        {
            return "CPU can't work with this xmp";
        }

        return "Success";
    }

    public string GraficCardBuild(GraficCard graficCard)
    {
        var builder = new GraficCardBuilder(graficCard.Name);
        builder.HeightCardBuild(graficCard.HeightCard);
        builder.WidthCardBuild(graficCard.WidthCard);
        builder.VersionPciEBuild(graficCard.VersionPciE);
        builder.PowerBuild(graficCard.Power);
        builder.ChipFrequencyBuild(graficCard.ChipFrequency);
        ComponentGraficCard = builder.GetGraficCard();
        if (ComponentGraficCard is not null && (ComponentGraficCard.HeightCard > ComponentComputerCase.Width
                                                 || ComponentGraficCard.WidthCard > ComponentComputerCase.Length))
        {
            return "very big grafic card";
        }

        return "Success";
    }

    public string HDDBuild(HDD hdd)
    {
        var builder = new HDDBuilder(hdd.Name);
        builder.MemoryBuild(hdd.Memory);
        builder.RotationSpeedBuild(hdd.RotationSpeed);
        builder.PowerBuild(hdd.Power);
        ComponentHdd = builder.GetHdd();
        if (ComponentHdd is null && ComponentSSD is null)
        {
            return "No data storage";
        }

        return "Success";
    }

    public string MotherboardBuild(Motherboard motherboard)
    {
        var builder = new MotherBoardBuilder(motherboard.Name);
        builder.SocketNameBuild(motherboard.SocketName);
        builder.PcieLineCountBuild(motherboard.PcieLineCount);
        builder.SataCountBuild(motherboard.SataCount);
        builder.ChipsetMotherboardBuild(motherboard.ChipsetMotherboard);
        builder.DDRBuild(motherboard.DDR);
        builder.RamCountBuild(motherboard.RamCount);
        builder.FormFactorBuild(motherboard.FormFactor);
        builder.BIOSBuild(motherboard.Bios);
        ComponentMotherboard = builder.GetMotherboard();
        if (ComponentMotherboard.FormFactor == ComponentComputerCase.FormFactor)
        {
            return "Success";
        }

        return "Moterboard from factor != Case form facrot";
    }

    public string PowerSupplyBuild(PowerSupply powerSupply)
    {
        var builder = new PowerSupplyBuilder(powerSupply.Name);
        builder.LoadPowerBuild(powerSupply.LoadPower);
        ComponentPowerSupply = builder.GetPowerSupply();
        if (ComponentGraficCard is not null && ComponentSSD is not null && ComponentHdd is null &&
            ComponentWifiModule is not null &&
            ComponentCPU.Power + ComponentGraficCard.Power + ComponentSSD.Power +
            ComponentWifiModule.Power > ComponentPowerSupply.LoadPower)
        {
            return "Success, but not enought power in power supply";
        }

        if (ComponentGraficCard is not null && ComponentSSD is null && ComponentHdd is not null &&
            ComponentWifiModule is not null &&
            ComponentCPU.Power + ComponentGraficCard.Power + ComponentHdd.Power +
            ComponentWifiModule.Power > ComponentPowerSupply.LoadPower)
        {
            return "Success, but not enought power in power supply";
        }

        return "Success";
    }

    public string RAMBuild(RAM ram)
    {
        var builder = new RAMBuilder(ram.Name);
        builder.MemoryBuild(ram.Memory);
        builder.VoltageBuild(ram.Voltage);
        builder.JedecEBuild(ram.JEDEC);
        builder.FormFactorBuild(ram.FormFactor);
        builder.DDRVersionBuild(ram.DDRVersion);
        foreach (string i in ram.XmpList)
        {
            builder.Add(i);
        }

        ComponentRam = builder.GetRAM();
        if (ComponentXmpProfile is not null && !ComponentRam.XmpList.Contains(ComponentXmpProfile.Name))
        {
            return "RAM can't work with this XMP";
        }

        return "Success";
    }

    public string SSDBuild(SSD ssd)
    {
        var builder = new SSDBuilder(ssd.Name);
        builder.MemoryBuild(ssd.Memory);
        builder.MaxSpeedWorkBuild(ssd.MaxSpeedWork);
        builder.PowerBuild(ssd.Power);
        builder.ConnectionOptionBuild(ssd.Option);
        ComponentSSD = builder.GetSSD();
        if (ComponentHdd is null && ComponentSSD is null)
        {
            return "No data storage";
        }

        if (ComponentSSD is not null && ComponentSSD.Option == ConnectionOption.PCIE && ComponentMotherboard.SataCount < 1)
        {
            return "no sota in motherboard";
        }

        if (ComponentSSD is not null && ComponentSSD.Option == ConnectionOption.PCIE && ComponentMotherboard.PcieLineCount < 1)
        {
            return "no sota in motherboard";
        }

        return "Success";
    }

    public string WIFIModuleBuild(WIFIModule wifiModule)
    {
        var builder = new WiFiModuleBuilder(wifiModule.Name);
        builder.VersionBuild(wifiModule.Version);
        builder.BluetoothBuild(wifiModule.Bluetooth);
        builder.PciEBuild(wifiModule.PCIE);
        builder.PowerBuild(wifiModule.Power);
        ComponentWifiModule = builder.GetWiFIModule();
        return "Success";
    }

    public string XMPProfileBuild(XMPProfile xmp)
    {
        var builder = new XMPBuilder(xmp.Name);
        builder.TimeBuild(xmp.Timing);
        builder.VoltageBuild(xmp.Voltage);
        builder.FrequencyBuild(xmp.Frequency);
        ComponentXmpProfile = builder.GetXmpProfile();
        return "Success";
    }
}