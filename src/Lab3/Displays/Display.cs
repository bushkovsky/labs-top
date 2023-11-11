using System;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;
using static Crayon.Output;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    public Display(Massage massage)
    {
        OutputMassage = massage;
    }

    public Massage OutputMassage { get; }

    public void OutputOnDisplay(Colors color)
    {
        Console.Clear();

        switch (color)
        {
            case Colors.Red:
                Console.WriteLine(Red(OutputMassage.Title + "\n" + OutputMassage.Body));
                break;
            case Colors.Blue:
                Console.WriteLine(Blue(OutputMassage.Title + "\n" + OutputMassage.Body));
                break;
            case Colors.Green:
                Console.WriteLine(Green(OutputMassage.Title + "\n" + OutputMassage.Body));
                break;
            default:
                Console.WriteLine(OutputMassage.Title + "\n" + OutputMassage.Body);
                break;
        }
    }
}