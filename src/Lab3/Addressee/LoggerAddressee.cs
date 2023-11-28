using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class LoggerAddressee : IAddressee
{
    private IAddressee _addressee;

    public LoggerAddressee(IAddressee addressee, ILogger logger)
    {
        Loggerr = logger;
        _addressee = addressee;
    }

    public ILogger Loggerr { get; }

    public void SendMassage(Massage massage, Color color)
    {
        Loggerr.LogAccess(massage, _addressee);
        _addressee.SendMassage(massage, color);
    }
}
