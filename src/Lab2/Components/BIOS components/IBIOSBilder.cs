using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IBIOSBilder
{
    public void Reset(string name, IList<string> cpus);

    public void TypeBuilder(string type);

    public void VersionBuild(int version);

    public void AddCpu(string cpu);

    public void Debuild(BIOS bios, string newName, IList<string> cpus);
    public BIOS GetBIOS();
}