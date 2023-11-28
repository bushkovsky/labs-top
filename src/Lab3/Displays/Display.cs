using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    private IDisplayDriver _displayDriver;
    public Display(Massage massage, IDisplayDriver displayDriver)
    {
        OutputMassage = massage;
        _displayDriver = displayDriver;
    }

    public Massage OutputMassage { get; private set; }
    public void OutputOnDisplay(int red, int green, int blue)
    {
        _displayDriver.ClearDisplay();
        Color color = _displayDriver.SetColor(red, green, blue);
        string text = Crayon.Output.Rgb(color.Red, color.Blue, color.Green).Text(" Massanger: " + OutputMassage.Title + "\n" + OutputMassage.Body);
        _displayDriver.Output(text);
    }

    public void UpdateMassage(Massage massage)
    {
        OutputMassage = massage;
    }
}