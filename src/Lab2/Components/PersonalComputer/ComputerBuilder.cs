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
        Reset(name);
    }

    public Computer MyComputer { get; private set; } = new Computer(" ");

    public void Reset(string name)
    {
        MyComputer = new Computer(name);
    }

    public void ComputerCaseBuild(ComputerCase computerCase)
    {
        var builder = new ComputerCaseBuilder(computerCase.Name);
        builder.GraficCardWidthBuild(computerCase.GraficCardWidth);
        builder.GraficCardLength(computerCase.GraficCardLength);
        builder.FormFactorBuild(computerCase.FormFactor);
        builder.WidthBuild(computerCase.Width);
        builder.LengthBuild(computerCase.Length);
        builder.HeightBuild(computerCase.Height);
        MyComputer.SetComputerCase(builder.GetComputerCase());
    }

    public string CoolingSystemBuild(CoolingSystem coolingSystem)
    {
        var builder = new CoolingSystemBuilder(coolingSystem.Name, coolingSystem.Sockets);
        builder.TDPBuild(coolingSystem.TDP);
        builder.SizeBuild(coolingSystem.Size);
        MyComputer.SetCoolingSystem(builder.GetCoolingSystem());

        if (!MyComputer.PcCoolingSystem.Sockets.Contains(MyComputer.PcCpu.Socket))
        {
            return "Socket of cooling system not the same socket of cpu";
        }

        if (MyComputer.PcCoolingSystem.Size > MyComputer.Case.Width)
        {
            return "Size of cooling system bigger then width of case";
        }

        if (MyComputer.PcCoolingSystem.TDP < MyComputer.PcCpu.TDP)
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
        MyComputer.SetCPU(builder.GetCPU());
        if (MyComputer.PcMotherboard.SocketName != MyComputer.PcCpu.Socket)
        {
            return "Sockets of motherboard and cpu not the same";
        }

        if (!MyComputer.PcMotherboard.Bios.SupportedProcessors.Contains(MyComputer.PcCpu.Name))
        {
            return "Bios can't use with this CPU";
        }

        if (MyComputer.PcXmpProfile is not null && !(MyComputer.PcCpu.MemoryFrequency == MyComputer.PcXmpProfile.Frequency))
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
        MyComputer.SetGraficCard(builder.GetGraficCard());
        if (MyComputer.PcGraficCard is not null && (MyComputer.PcGraficCard.HeightCard > MyComputer.Case.Width
                                                   || MyComputer.PcGraficCard.WidthCard > MyComputer.Case.Length))
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
        MyComputer.SetHDD(builder.GetHdd());
        if (MyComputer.PcHDD is null && MyComputer.PcSSD is null)
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
        MyComputer.SetMotherboard(builder.GetMotherboard());
        if (MyComputer.PcMotherboard.FormFactor == MyComputer.Case.FormFactor)
        {
            return "Success";
        }

        return "Moterboard from factor != Case form facrot";
    }

    public string PowerSupplyBuild(PowerSupply powerSupply)
    {
        var builder = new PowerSupplyBuilder(powerSupply.Name);
        builder.LoadPowerBuild(powerSupply.LoadPower);
        MyComputer.SetPowerSupply(builder.GetPowerSupply());
        if (MyComputer.PcGraficCard is not null && MyComputer.PcSSD is not null && MyComputer.PcHDD is null &&
            MyComputer.PcWifiModule is not null &&
            MyComputer.PcCpu.Power + MyComputer.PcGraficCard.Power + MyComputer.PcSSD.Power +
            MyComputer.PcWifiModule.Power > MyComputer.PcPowerSupply.LoadPower)
        {
            return "Success, but not enought power in power supply";
        }

        if (MyComputer.PcGraficCard is not null && MyComputer.PcSSD is null && MyComputer.PcHDD is not null &&
            MyComputer.PcWifiModule is not null &&
            MyComputer.PcCpu.Power + MyComputer.PcGraficCard.Power + MyComputer.PcHDD.Power +
            MyComputer.PcWifiModule.Power > MyComputer.PcPowerSupply.LoadPower)
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

        MyComputer.SetRAM(builder.GetRAM());
        if (MyComputer.PcXmpProfile is not null && !MyComputer.PcRam.XmpList.Contains(MyComputer.PcXmpProfile.Name))
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
        MyComputer.SetSSD(builder.GetSSD());
        if (MyComputer.PcHDD is null && MyComputer.PcSSD is null)
        {
            return "No data storage";
        }

        if (MyComputer.PcSSD is not null && MyComputer.PcSSD.Option == ConnectionOption.PCIE && MyComputer.PcMotherboard.SataCount < 1)
        {
            return "no sota in motherboard";
        }

        if (MyComputer.PcSSD is not null && MyComputer.PcSSD.Option == ConnectionOption.PCIE && MyComputer.PcMotherboard.PcieLineCount < 1)
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
        MyComputer.SetWIFIModule(builder.GetWiFIModule());
        return "Success";
    }

    public string XMPProfileBuild(XMPProfile xmp)
    {
        var builder = new XMPBuilder(xmp.Name);
        builder.TimeBuild(xmp.Timing);
        builder.VoltageBuild(xmp.Voltage);
        builder.FrequencyBuild(xmp.Frequency);
        MyComputer.SetXMPProfile(builder.GetXmpProfile());
        return "Success";
    }
}