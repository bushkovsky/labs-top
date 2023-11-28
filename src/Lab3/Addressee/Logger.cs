using System;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public record Logger : ILogger
{
    private string _logMassage;

    public Logger(string logMassage)
    {
        _logMassage = logMassage;
    }

    public void LogAccess(Massage message, IAddressee addressee)
    {
        Console.WriteLine("Log:" + message.Title + "was send to" + addressee.ToString());
    }
}
