using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class MessengerAddressee : IAddressee
{
    public MessengerAddressee(IMessenger messenger)
    {
        Messenger = messenger;
    }

    public IMessenger Messenger { get; }
    public void SendMassage(Massage massage, Color color)
    {
        Messenger.PrintMassage(massage);
    }
}