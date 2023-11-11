using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger : IMessenger
{
    public string PrintMassage(IEnumerable<Massage> massages)
    {
        string result = " ";
        foreach (Massage i in massages)
        {
            result += "Massanger: " + i.Title + "\n" + i.Body;
            Console.WriteLine("Massanger: " + i.Title + "\n" + i.Body);
        }

        return result;
    }
}