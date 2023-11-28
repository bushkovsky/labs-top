using System;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger : IMessenger
{
    public void PrintMassage(Massage massage)
    {
        Console.WriteLine("Massanger: " + massage.Title + "\n" + massage.Body);
    }
}