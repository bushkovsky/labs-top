using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class CoolingSystem : IComponent
{
    public CoolingSystem(string name, IList<string> sockets)
    {
        Name = name;
        Sockets = sockets;
    }

    public string Name { get; }
    public IList<string> Sockets { get; private set; }
    public int TDP { get; private set; }

    public int Size { get; private set; }

    public void SetTDP(int tdp)
    {
        TDP = tdp;
    }

    public void Add(string socket)
    {
        Sockets.Add(socket);
    }

    public void SetSize(int size)
    {
        Size = size;
    }
}