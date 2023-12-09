using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class GroupAddressee : IAddressee
{
    private IList<IAddressee> _addressees;

    public GroupAddressee(IList<IAddressee> addressees)
    {
        _addressees = addressees;
    }

    public void SendMassage(Massage massage)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.SendMassage(massage);
        }
    }
}