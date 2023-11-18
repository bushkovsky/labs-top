using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class BIOSBilder : IBIOSBilder
{
    private BIOS _bios = new BIOS(" ", new List<string>());

    public BIOSBilder(string name, IList<string> cpus)
    {
        Reset(name, cpus);
    }

    public void Reset(string name, IList<string> cpus)
    {
        _bios = new BIOS(name, cpus);
    }

    public void TypeBuilder(string type)
    {
        _bios.SetType(type);
    }

    public void VersionBuild(int version)
    {
        _bios.SetVersion(version);
    }

    public void AddCpu(string cpu)
    {
        _bios.Add(cpu);
    }

    public void Debuild(BIOS bios, string newName, IList<string> cpus)
    {
        Reset(newName, cpus);
        TypeBuilder(bios.Type);
        VersionBuild(bios.Version);
    }

    public BIOS GetBIOS()
    {
        BIOS result = _bios;
        Reset(" ", new List<string>());
        return result;
    }
}