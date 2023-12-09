using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class DisplayAddressee : IAddressee
{
    public DisplayAddressee(Display display)
    {
        DisplayON = display;
    }

    public IDisplay DisplayON { get; }

    public void SendMassage(Massage massage)
    {
        DisplayON.OutputOnDisplay(massage);
    }
}