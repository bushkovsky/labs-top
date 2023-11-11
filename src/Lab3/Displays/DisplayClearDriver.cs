using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class DisplayClearDriver : DisplayDriver
{
    public DisplayClearDriver(IDisplay display)
        : base(display) { }

    public static void ClearOutput()
    {
        Console.Clear();
    }
}