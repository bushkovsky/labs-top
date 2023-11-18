using System;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    public Display(Massage massage)
    {
        OutputMassage = massage;
    }

    public Massage OutputMassage { get; private set; }
    public void OutputOnDisplay(int red, int green, int blue)
    {
        DisplayDriver.ClearDisplay();
        DisplayDriver.SetColor(red, green, blue);
        string text = Crayon.Output.Rgb((byte)red, (byte)green, (byte)blue).Text(" Massanger: " + OutputMassage.Title + "\n" + OutputMassage.Body);
        Console.WriteLine(text);
    }

    public void UpdateMassage(Massage massage)
    {
        OutputMassage = massage;
    }
}