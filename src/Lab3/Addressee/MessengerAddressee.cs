using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class MessengerAddressee : IAddressee, IMessenger
{
    private Messenger _messenger;

    public MessengerAddressee(Messenger messenger)
    {
        _messenger = messenger;
    }

    public void LogAccess()
    {
        Console.WriteLine("Proxy: Messenger get massage ");
    }

    public string PrintMassage(IEnumerable<Massage> massages)
    {
        LogAccess();
        return _messenger.PrintMassage(massages);
    }
}