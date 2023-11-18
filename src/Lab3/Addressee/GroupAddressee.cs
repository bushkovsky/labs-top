using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class GroupAddressee : IAddressee
{
    private IList<IAddressee> _addressees;

    public GroupAddressee(IList<IAddressee> addressees, ILogger logger)
    {
        _addressees = addressees;
        LoggerGroup = logger;
    }

    public ILogger LoggerGroup { get; }

    public void SendMassage(Massage massage, Color color)
    {
        LoggerGroup.LogAccess();
        foreach (IAddressee i in _addressees)
        {
            i.SendMassage(massage, color);
        }
    }

    public bool LevelFilter(int level, Massage massage)
    {
        return massage.RelevanceLevel <= level;
    }

    public bool SendMassageFilter(Massage massage, Color color, int level)
    {
        LoggerGroup.LogAccess();
        foreach (IAddressee i in _addressees)
        {
            if (!i.SendMassageFilter(massage, color, level))
            {
                return false;
            }
        }

        return true;
    }
}