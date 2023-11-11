using System;
using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class DisplayAddressee : IAddressee, IDisplay
{
    public DisplayAddressee(Display display)
    {
        DisplayON = display;
        OutputMassage = display.OutputMassage;
    }

    public Display DisplayON { get; }

    public Massage OutputMassage { get; }

    public void LogAccess()
    {
        Console.WriteLine("Proxy: Display write massage ");
    }

    public void OutputOnDisplay(Colors color)
    {
       DisplayON.OutputOnDisplay(color);
       LogAccess();
    }
}