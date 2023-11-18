using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface ICoolingSystemBuilder
{
    public void Reset(string name, IList<string> sockets);

    public void TDPBuild(int tdp);

    public void SizeBuild(int size);

    public void Add(string socket);

    public void Debuild(CoolingSystem coolingSystem, string newName, IList<string> sockets);

    public CoolingSystem GetCoolingSystem();
}