using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Components.GraficCardcomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.HDDcomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.PersonalComputer;
using Itmo.ObjectOrientedProgramming.Lab2.Components.PowerSupplycomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.RAMcomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.SSDcomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.WIFIcomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.XMPProfilecomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Components.СomputerСasecomponents;
using Itmo.ObjectOrientedProgramming.Lab2.RepositoryComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCСonfigurator;

public class Configurator
{
    /*
     * public string Name { get; }
    public ComputerCase Case { get; private set; } = new ComputerCase(" ");
    public CoolingSystem PcCoolingSystem { get; private set; } = new CoolingSystem(" ", new List<string>());
    public CPU PcCpu { get; private set; } = new CPU(" ");
    public GraficCard? PcGraficCard { get; private set; }
    public HDD? PcHDD { get; private set; }
    public Motherboard PcMotherboard { get; private set; } = new Motherboard(" ");
    public PowerSupply PcPowerSupply { get; private set; } = new PowerSupply(" ");
    public RAM.RAM PcRam { get; private set; } = new RAM.RAM(" ");
    public SSD? PcSSD { get; private set; }
    public WIFIModule? PcWifiModule { get; private set; }
    public XMPProfile? PcXmpProfile { get; private set; }
     */
    private readonly Repository<IComponent> _repository;
    private string _massage = "Succes";

    public Configurator()
    {
        _repository = new Repository<IComponent>();
    }

    public void AddComponent(IComponent component)
    {
        _repository.Add(component);
    }

    public string BuildNewComputer(string name, IList<IComponent> components)
    {
        var builder = new ComputerBuilder(name);
        var pcCase = new List<ComputerCase>(components.OfType<ComputerCase>());
        AddComponent(pcCase[0]);
        builder.ComputerCaseBuild(pcCase[0]);

        var pcMotherBoard = new List<Motherboard>(components.OfType<Motherboard>());
        _massage = builder.MotherboardBuild(pcMotherBoard[0]);
        AddComponent(pcMotherBoard[0]);
        if (CheckMassage(_massage))
        {
            return _massage;
        }

        var pcXmp = new List<XMPProfile>(components.OfType<XMPProfile>());
        _massage = builder.XMPProfileBuild(pcXmp[0]);
        AddComponent(pcXmp[0]);
        if (CheckMassage(_massage))
        {
            return _massage;
        }

        var pcGraficCard = new List<GraficCard>(components.OfType<GraficCard>());
        _massage = builder.GraficCardBuild(pcGraficCard[0]);
        AddComponent(pcGraficCard[0]);
        if (CheckMassage(_massage))
        {
            return _massage;
        }

        var pcCpu = new List<CPU>(components.OfType<CPU>());
        _massage = builder.CPUBuild(pcCpu[0]);
        AddComponent(pcCpu[0]);
        if (CheckMassage(_massage))
        {
            return _massage;
        }

        var pcRam = new List<RAM>(components.OfType<RAM>());
        _massage = builder.RAMBuild(pcRam[0]);
        AddComponent(pcRam[0]);
        if (CheckMassage(_massage))
        {
            return _massage;
        }

        var pcSSD = new List<SSD>(components.OfType<SSD>());
        if (pcSSD.Count != 0)
        {
            _massage = builder.SSDBuild(pcSSD[0]);
            AddComponent(pcSSD[0]);
            if (CheckMassage(_massage))
            {
                return _massage;
            }
        }

        var pcHDD = new List<HDD>(components.OfType<HDD>());
        if (pcHDD.Count != 0)
        {
            _massage = builder.HDDBuild(pcHDD[0]);
            AddComponent(pcHDD[0]);
            if (CheckMassage(_massage))
            {
                return _massage;
            }
        }

        var pcWiFi = new List<WIFIModule>(components.OfType<WIFIModule>());
        _massage = builder.WIFIModuleBuild(pcWiFi[0]);
        AddComponent(pcWiFi[0]);

        var pcCoolingSystem = new List<CoolingSystem>(components.OfType<CoolingSystem>());
        _massage = builder.CoolingSystemBuild(pcCoolingSystem[0]);
        AddComponent(pcCoolingSystem[0]);
        if (CheckMassage(_massage))
        {
            return _massage;
        }

        var pcPowerSupply = new List<PowerSupply>(components.OfType<PowerSupply>());
        _massage = builder.PowerSupplyBuild(pcPowerSupply[0]);
        AddComponent(pcPowerSupply[0]);

        return _massage;
    }

    private static bool CheckMassage(string massage)
    {
        if (massage != "Success")
        {
            return true;
        }

        return false;
    }
}