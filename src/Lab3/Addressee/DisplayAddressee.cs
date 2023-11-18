using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class DisplayAddressee : IAddressee
{
    public DisplayAddressee(Display display, ILogger logger)
    {
        DisplayON = display;
        LoggerDisplay = logger;

        OutputMassage = display.OutputMassage;
    }

    public IDisplay DisplayON { get; }
    public ILogger LoggerDisplay { get; }

    public Massage OutputMassage { get; }

    public void SendMassage(Massage massage, Color color)
    {
        LoggerDisplay.LogAccess();
        DisplayON.UpdateMassage(massage);
        DisplayON.OutputOnDisplay(color.Red, color.Blue, color.Green);
    }

    public bool LevelFilter(int level, Massage massage)
    {
        return massage.RelevanceLevel <= level;
    }

    public bool SendMassageFilter(Massage massage, Color color, int level)
    {
        if (!LevelFilter(level, massage)) return false;
        SendMassage(massage, color);
        return true;
    }
}