using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class DisplayDriver : IDisplay
{
    public DisplayDriver(IDisplay display)
    {
        ConcreteDisplay = display;
        OutputMassage = display.OutputMassage;
    }

    public Massage OutputMassage { get; }
    protected IDisplay ConcreteDisplay { get; private protected set; }

    public void OutputOnDisplay(Colors color)
    {
        ConcreteDisplay.OutputOnDisplay(color);
    }
}