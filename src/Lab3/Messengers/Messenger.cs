using System;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger : IMessenger
{
    public string PrintMassage(Massage massage)
    {
        string result = " ";
        Console.WriteLine("Massanger: " + massage.Title + "\n" + massage.Body);
        result += "Massanger: " + massage.Title + "\n" + massage.Body;
        return result;
    }
}