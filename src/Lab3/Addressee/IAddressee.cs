using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public interface IAddressee
{
    public void SendMassage(Massage massage, Color color);
}