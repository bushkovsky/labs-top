using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public record Logger : ILogger
{
    private string _logMassage;

    public Logger(string logMassage)
    {
        _logMassage = logMassage;
    }

    public void LogAccess()
    {
        Console.WriteLine(_logMassage);
    }
}
