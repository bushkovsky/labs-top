using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class GroupAddressee : IAddressee
{
    private IList<IAddressee> _addressees;

    public GroupAddressee(IList<IAddressee> addressees)
    {
        _addressees = addressees;
    }

    public void SendMassage(Massage massage, Color color)
    {
        foreach (IAddressee i in _addressees)
        {
            i.SendMassage(massage, color);
        }
    }
}