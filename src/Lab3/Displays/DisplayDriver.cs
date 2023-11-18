using System;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public static class DisplayDriver
{
    public static Massage SetText(string title, string body, int level)
    {
        return new Massage(title, body, level);
    }

    public static Color SetColor(int red, int green, int blue)
    {
        return new Color(red, green, blue);
    }

    public static void ClearDisplay()
    {
        Console.Clear();
    }
}