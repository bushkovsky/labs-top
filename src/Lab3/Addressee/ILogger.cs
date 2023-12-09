using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public interface ILogger
{
    public void LogAccess(Massage message, IAddressee addressee);
}