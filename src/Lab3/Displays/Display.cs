using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    private IDisplayDriver _displayDriver;
    public Display(IDisplayDriver displayDriver, Color displayColor)
    {
        _displayDriver = displayDriver;
        DisplayColor = displayColor;
    }

    public Color DisplayColor { get; }

    public void OutputOnDisplay(Massage massage)
    {
        _displayDriver.ClearDisplay();
        _displayDriver.Output(massage);
    }
}