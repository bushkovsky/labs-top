using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class DisplayAddressee : IAddressee
{
    public DisplayAddressee(Display display)
    {
        DisplayON = display;
        OutputMassage = display.OutputMassage;
    }

    public IDisplay DisplayON { get; }
    public Massage OutputMassage { get; }

    public void SendMassage(Massage massage, Color color)
    {
        DisplayON.UpdateMassage(massage);
        DisplayON.OutputOnDisplay(color.Red, color.Blue, color.Green);
    }
}