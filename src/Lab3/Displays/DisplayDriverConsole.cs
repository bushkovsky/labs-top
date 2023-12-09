using System;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class DisplayDriverConsole : IDisplayDriver
{
    private Color _color = new Color(0, 0, 0);

    public void SetColor(int red, int green, int blue)
    {
        _color = new Color(red, green, blue);
    }

    public void ClearDisplay()
    {
        Console.Clear();
    }

    public void Output(Massage massage)
    {
        string text = Crayon.Output.Rgb(_color.Red, _color.Blue, _color.Green).Text(" Massanger: " + massage.Title + "\n" + massage.Body);
        Console.WriteLine(text);
    }
}