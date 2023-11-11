namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class DisplayColorDriver : DisplayDriver
{
    public DisplayColorDriver(IDisplay display)
        : base(display)
    {
    }

    public Colors TextColor { get; private set; } = Colors.None;

    public void ChooseColor(Colors color)
    {
        TextColor = color;
    }

    public void OutputOnDisplay()
    {
        OutputOnDisplay(TextColor);
    }
}