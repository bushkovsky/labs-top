using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class DisplayNewTextDriver : DisplayDriver
{
    public DisplayNewTextDriver(IDisplay display)
        : base(display)
    {
    }

    public void WriteNewText(string newText)
    {
        var massageWithNewText = new Massage(ConcreteDisplay.OutputMassage.Title,  newText, ConcreteDisplay.OutputMassage.RelevanceLevel);
        ConcreteDisplay = new Display(massageWithNewText);
    }
}