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
        if (red == 1)
        {
            Console.WriteLine(Crayon.Output.Red("Massage" + OutputMassage.Title + "\n" + OutputMassage.Body));
        }
        else if (green == 1)
        {
            Console.WriteLine(Crayon.Output.Green("Massage" + OutputMassage.Title + "\n" + OutputMassage.Body));
        }
        else if (blue == 1)
        {
            Console.WriteLine(Crayon.Output.Blue("Massage" + OutputMassage.Title + "\n" + OutputMassage.Body));
        }
    }

    public void UpdateMassage(Massage massage)
    {
        OutputMassage = massage;
    }
}