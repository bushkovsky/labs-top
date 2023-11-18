using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Components.GraficCardcomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.HDDcomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.PowerSupplycomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.RAMcomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.WIFIcomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.XMPProfilecomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.СomputerСasecomponents;
using Itmo.ObjectOrientedProgramming.Lab2.PCСonfigurator;
using Xunit;
namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class LabTwoTestOfComputerComponents
{
    public static IEnumerable<object[]> ReadyPcTestData()
    {
        var computerCase = new ComputerCase("GoodPcCase");
        computerCase.SetHeight(100);
        computerCase.SetLength(100);
        computerCase.SetWidth(100);
        computerCase.SetFormFactor("xcmpt");
        computerCase.SetGraficCardLength(50);
        computerCase.SetGraficCardWidth(40);

        var socketsCooling = new List<string>();
        socketsCooling.Add("socket123");
        var coolingSystem = new CoolingSystem("cool", socketsCooling);
        coolingSystem.SetSize(10);
        coolingSystem.SetTDP(60);

        var cpu = new CPU("intel 5");
        cpu.SetPower(30);
        cpu.SetTDP(50);
        cpu.SetSocket("socket123");
        cpu.SetCoreFrequency(40);
        cpu.SetCountCore(4);
        cpu.SetGraficModification(true);
        cpu.SetMemoryFrequency(40);

        var bios = new BIOS("bios2.0", new List<string>());
        bios.SetVersion(5);
        bios.SetType("bios2.0");
        bios.Add(cpu.Name);

        var graficCard = new GraficCard("Gygabyte 500R");
        graficCard.SetPower(20);
        graficCard.SetHeightCard(10);
        graficCard.SetWidthCard(8);
        graficCard.SetChipFrequency(20);
        graficCard.SetVersionPciE(4);

        var hdd = new HDD("kingstonFive");
        hdd.SetPower(10);
        hdd.SetMemory(500);
        hdd.SetRotationSpeed(9);

        var motherboard = new Motherboard("MSI coolboard");
        motherboard.SetFormFactor("xcmpt");
        motherboard.SetBios(bios);
        motherboard.SetChipsetMotherboard(new Chipset("chipset", 10, true));
        motherboard.SetDDR("ddr");
        motherboard.SetRamCount(3);
        motherboard.SetSataCount(5);
        motherboard.SetSocketName("socket123");
        motherboard.SetPcieLineCount(5);

        var powerSupply = new PowerSupply("power200");
        powerSupply.SetLoadPower(5000);

        var xmpProfile = new XMPProfile("xmp");
        xmpProfile.SetTiming(100);
        xmpProfile.SetFrequency(40);
        xmpProfile.SetVoltage(40);

        var ram = new RAM("kingston", new List<string>()); // string
        ram.Add(xmpProfile.Name);
        ram.SetMemory(5);
        ram.SetVoltage(5);
        ram.SetFormFactor(" ");

        var wifiModule = new WIFIModule("wifi");
        wifiModule.SetPower(5);
        wifiModule.SetVersion(1);
        wifiModule.SetPCIE(1);
        wifiModule.SetBluetooth(true);

        yield return new object[]
        {
            wifiModule, ram, motherboard, xmpProfile, powerSupply, hdd, graficCard, cpu, computerCase, coolingSystem,
        };
    }

    public static IEnumerable<object[]> ReadyPcTestDataPower()
    {
        var computerCase = new ComputerCase("GoodPcCase");
        computerCase.SetHeight(100);
        computerCase.SetLength(100);
        computerCase.SetWidth(100);
        computerCase.SetFormFactor("xcmpt");
        computerCase.SetGraficCardLength(50);
        computerCase.SetGraficCardWidth(40);

        var socketsCooling = new List<string>();
        socketsCooling.Add("socket123");
        var coolingSystem = new CoolingSystem("cool", socketsCooling);
        coolingSystem.SetSize(10);
        coolingSystem.SetTDP(60);

        var cpu = new CPU("intel 5");
        cpu.SetPower(30);
        cpu.SetTDP(50);
        cpu.SetSocket("socket123");
        cpu.SetCoreFrequency(40);
        cpu.SetCountCore(4);
        cpu.SetGraficModification(true);
        cpu.SetMemoryFrequency(40);

        var bios = new BIOS("bios2.0", new List<string>());
        bios.SetVersion(5);
        bios.SetType("bios2.0");
        bios.Add(cpu.Name);

        var graficCard = new GraficCard("Gygabyte 500R");
        graficCard.SetPower(20);
        graficCard.SetHeightCard(10);
        graficCard.SetWidthCard(8);
        graficCard.SetChipFrequency(20);
        graficCard.SetVersionPciE(4);

        var hdd = new HDD("kingstonFive");
        hdd.SetPower(10);
        hdd.SetMemory(500);
        hdd.SetRotationSpeed(9);

        var motherboard = new Motherboard("MSI coolboard");
        motherboard.SetFormFactor("xcmpt");
        motherboard.SetBios(bios);
        motherboard.SetChipsetMotherboard(new Chipset("chipset", 10, true));
        motherboard.SetDDR("ddr");
        motherboard.SetRamCount(3);
        motherboard.SetSataCount(5);
        motherboard.SetSocketName("socket123");
        motherboard.SetPcieLineCount(5);

        var powerSupply = new PowerSupply("power200");
        powerSupply.SetLoadPower(20);

        var xmpProfile = new XMPProfile("xmp");
        xmpProfile.SetTiming(100);
        xmpProfile.SetFrequency(40);
        xmpProfile.SetVoltage(40);

        var ram = new RAM("kingston", new List<string>()); // string
        ram.Add(xmpProfile.Name);
        ram.SetMemory(5);
        ram.SetVoltage(5);
        ram.SetFormFactor(" ");

        var wifiModule = new WIFIModule("wifi");
        wifiModule.SetPower(20);
        wifiModule.SetVersion(1);
        wifiModule.SetPCIE(1);
        wifiModule.SetBluetooth(true);

        yield return new object[]
        {
            wifiModule, ram, motherboard, xmpProfile, powerSupply, hdd, graficCard, cpu, computerCase, coolingSystem,
        };
    }

    public static IEnumerable<object[]> ReadyPcTestDataCoolingSystem()
    {
        var computerCase = new ComputerCase("GoodPcCase");
        computerCase.SetHeight(100);
        computerCase.SetLength(100);
        computerCase.SetWidth(100);
        computerCase.SetFormFactor("xcmpt");
        computerCase.SetGraficCardLength(50);
        computerCase.SetGraficCardWidth(40);

        var socketsCooling = new List<string>();
        socketsCooling.Add("socket123");
        var coolingSystem = new CoolingSystem("cool", socketsCooling);
        coolingSystem.SetSize(10);
        coolingSystem.SetTDP(5);

        var cpu = new CPU("intel 5");
        cpu.SetPower(30);
        cpu.SetTDP(50);
        cpu.SetSocket("socket123");
        cpu.SetCoreFrequency(40);
        cpu.SetCountCore(4);
        cpu.SetGraficModification(true);
        cpu.SetMemoryFrequency(40);

        var bios = new BIOS("bios2.0", new List<string>());
        bios.SetVersion(5);
        bios.SetType("bios2.0");
        bios.Add(cpu.Name);

        var graficCard = new GraficCard("Gygabyte 500R");
        graficCard.SetPower(20);
        graficCard.SetHeightCard(10);
        graficCard.SetWidthCard(8);
        graficCard.SetChipFrequency(20);
        graficCard.SetVersionPciE(4);

        var hdd = new HDD("kingstonFive");
        hdd.SetPower(10);
        hdd.SetMemory(500);
        hdd.SetRotationSpeed(9);

        var motherboard = new Motherboard("MSI coolboard");
        motherboard.SetFormFactor("xcmpt");
        motherboard.SetBios(bios);
        motherboard.SetChipsetMotherboard(new Chipset("chipset", 10, true));
        motherboard.SetDDR("ddr");
        motherboard.SetRamCount(3);
        motherboard.SetSataCount(5);
        motherboard.SetSocketName("socket123");
        motherboard.SetPcieLineCount(5);

        var powerSupply = new PowerSupply("power200");
        powerSupply.SetLoadPower(5000);

        var xmpProfile = new XMPProfile("xmp");
        xmpProfile.SetTiming(100);
        xmpProfile.SetFrequency(40);
        xmpProfile.SetVoltage(40);

        var ram = new RAM("kingston", new List<string>()); // string
        ram.Add(xmpProfile.Name);
        ram.SetMemory(5);
        ram.SetVoltage(5);
        ram.SetFormFactor(" ");

        var wifiModule = new WIFIModule("wifi");
        wifiModule.SetPower(5);
        wifiModule.SetVersion(1);
        wifiModule.SetPCIE(1);
        wifiModule.SetBluetooth(true);

        yield return new object[]
        {
            wifiModule, ram, motherboard, xmpProfile, powerSupply, hdd, graficCard, cpu, computerCase, coolingSystem,
        };
    }

    public static IEnumerable<object[]> ReadyPcTestDataCoolingAndCPUSockets()
    {
        var computerCase = new ComputerCase("GoodPcCase");
        computerCase.SetHeight(100);
        computerCase.SetLength(100);
        computerCase.SetWidth(100);
        computerCase.SetFormFactor("xcmpt");
        computerCase.SetGraficCardLength(50);
        computerCase.SetGraficCardWidth(40);

        var socketsCooling = new List<string>();
        socketsCooling.Add("socket123");
        var coolingSystem = new CoolingSystem("cool", socketsCooling);
        coolingSystem.SetSize(10);
        coolingSystem.SetTDP(60);

        var cpu = new CPU("intel 5");
        cpu.SetPower(30);
        cpu.SetTDP(50);
        cpu.SetSocket("socket1234");
        cpu.SetCoreFrequency(40);
        cpu.SetCountCore(4);
        cpu.SetGraficModification(true);
        cpu.SetMemoryFrequency(40);

        var bios = new BIOS("bios2.0", new List<string>());
        bios.SetVersion(5);
        bios.SetType("bios2.0");
        bios.Add(cpu.Name);

        var graficCard = new GraficCard("Gygabyte 500R");
        graficCard.SetPower(20);
        graficCard.SetHeightCard(10);
        graficCard.SetWidthCard(8);
        graficCard.SetChipFrequency(20);
        graficCard.SetVersionPciE(4);

        var hdd = new HDD("kingstonFive");
        hdd.SetPower(10);
        hdd.SetMemory(500);
        hdd.SetRotationSpeed(9);

        var motherboard = new Motherboard("MSI coolboard");
        motherboard.SetFormFactor("xcmpt");
        motherboard.SetBios(bios);
        motherboard.SetChipsetMotherboard(new Chipset("chipset", 10, true));
        motherboard.SetDDR("ddr");
        motherboard.SetRamCount(3);
        motherboard.SetSataCount(5);
        motherboard.SetSocketName("socket123");
        motherboard.SetPcieLineCount(5);

        var powerSupply = new PowerSupply("power200");
        powerSupply.SetLoadPower(5000);

        var xmpProfile = new XMPProfile("xmp");
        xmpProfile.SetTiming(100);
        xmpProfile.SetFrequency(40);
        xmpProfile.SetVoltage(40);

        var ram = new RAM("kingston", new List<string>()); // string
        ram.Add(xmpProfile.Name);
        ram.SetMemory(5);
        ram.SetVoltage(5);
        ram.SetFormFactor(" ");

        var wifiModule = new WIFIModule("wifi");
        wifiModule.SetPower(5);
        wifiModule.SetVersion(1);
        wifiModule.SetPCIE(1);
        wifiModule.SetBluetooth(true);

        yield return new object[]
        {
            wifiModule, ram, motherboard, xmpProfile, powerSupply, hdd, graficCard, cpu, computerCase, coolingSystem,
        };
    }

    [Theory]
    [MemberData(nameof(ReadyPcTestData))]
    public void ReadyPcTest(WIFIModule wifiModule, RAM ram, Motherboard motherboard, XMPProfile xmpProfile, PowerSupply powerSupply, HDD hdd, GraficCard graficCard, CPU cpu, ComputerCase computerCase, CoolingSystem coolingSystem)
    {
        var configurator = new Configurator();
        var components = new List<IComponent>
        {
            wifiModule,
            ram,
            motherboard,
            xmpProfile,
            powerSupply,
            hdd,
            graficCard,
            cpu,
            computerCase,
            coolingSystem,
        };

        Assert.Equal("Success", configurator.BuildNewComputer("GreatComputer", components));
    }

    [Theory]
    [MemberData(nameof(ReadyPcTestDataPower))]
    public void ReadyPcLowPower(WIFIModule wifiModule, RAM ram, Motherboard motherboard, XMPProfile xmpProfile, PowerSupply powerSupply, HDD hdd, GraficCard graficCard, CPU cpu, ComputerCase computerCase, CoolingSystem coolingSystem)
    {
        var configurator = new Configurator();
        var components = new List<IComponent>
        {
            wifiModule,
            ram,
            motherboard,
            xmpProfile,
            powerSupply,
            hdd,
            graficCard,
            cpu,
            computerCase,
            coolingSystem,
        };

        Assert.Equal("Success, but not enought power in power supply", configurator.BuildNewComputer("GreatComputer", components));
    }

    [Theory]
    [MemberData(nameof(ReadyPcTestDataCoolingSystem))]
    public void ReadyPcTestCoolingSystem(WIFIModule wifiModule, RAM ram, Motherboard motherboard, XMPProfile xmpProfile, PowerSupply powerSupply, HDD hdd, GraficCard graficCard, CPU cpu, ComputerCase computerCase, CoolingSystem coolingSystem)
    {
        var configurator = new Configurator();
        var components = new List<IComponent>
        {
            wifiModule,
            ram,
            motherboard,
            xmpProfile,
            powerSupply,
            hdd,
            graficCard,
            cpu,
            computerCase,
            coolingSystem,
        };

        Assert.Equal("Success, but disclaimer of warranty obligations", configurator.BuildNewComputer("GreatComputer", components));
    }

    [Theory]
    [MemberData(nameof(ReadyPcTestDataCoolingAndCPUSockets))]
    public void ReadyPcTestCoolingCPUSockets(WIFIModule wifiModule, RAM ram, Motherboard motherboard, XMPProfile xmpProfile, PowerSupply powerSupply, HDD hdd, GraficCard graficCard, CPU cpu, ComputerCase computerCase, CoolingSystem coolingSystem)
    {
        var configurator = new Configurator();
        var components = new List<IComponent>
        {
            wifiModule,
            ram,
            motherboard,
            xmpProfile,
            powerSupply,
            hdd,
            graficCard,
            cpu,
            computerCase,
            coolingSystem,
        };

        Assert.Equal("Sockets of motherboard and cpu not the same", configurator.BuildNewComputer("GreatComputer", components));
    }
}
