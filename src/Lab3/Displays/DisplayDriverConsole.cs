using System;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class DisplayDriverConsole : IDisplayDriver
{
    public Massage SetText(string title, string body, int level)
    {
        return new Massage(title, body, level);
    }

    public Color SetColor(int red, int green, int blue)
    {
        return new Color(red, green, blue);
    }

    public void ClearDisplay()
    {
        Console.Clear();
    }

    public void Output(string text)
    {
        Console.WriteLine(text);
    }
}