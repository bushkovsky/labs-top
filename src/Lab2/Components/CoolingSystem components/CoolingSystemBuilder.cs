using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class CoolingSystemBuilder : ICoolingSystemBuilder
{
    /*
     * public string Name { get; }
    public IList<string> Sockets { get; private set; }
    public int TDP { get; private set; }
     */

    private CoolingSystem _coolingSystem = new CoolingSystem(" ", new List<string>());

    public CoolingSystemBuilder(string name, IList<string> sockets)
    {
        Reset(name, sockets);
    }

    public void Reset(string name,  IList<string> sockets)
    {
        _coolingSystem = new CoolingSystem(name, sockets);
    }

    public void TDPBuild(int tdp)
    {
        _coolingSystem.SetTDP(tdp);
    }

    public void SizeBuild(int size)
    {
        _coolingSystem.SetSize(size);
    }

    public void Add(string socket)
    {
        _coolingSystem.Add(socket);
    }

    public void Debuild(CoolingSystem coolingSystem, string newName, IList<string> sockets)
    {
        Reset(newName, sockets);
        TDPBuild(coolingSystem.TDP);
        SizeBuild(coolingSystem.Size);
    }

    public CoolingSystem GetCoolingSystem()
    {
        CoolingSystem result = _coolingSystem;
        Reset(" ", new List<string>());
        return result;
    }
}