using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class MessengerAddressee : IAddressee
{
    public MessengerAddressee(Messenger messenger, ILogger loggerMessenger)
    {
        Messenger = messenger;
        LoggerMessenger = loggerMessenger;
    }

    public Messenger Messenger { get; }
    public ILogger LoggerMessenger { get; }

    public void SendMassage(Massage massage, Color color)
    {
        LoggerMessenger.LogAccess();
        Messenger.PrintMassage(massage);
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