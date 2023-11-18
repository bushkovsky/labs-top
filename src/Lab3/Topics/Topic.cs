using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic
{
    public Topic(string name, IAddressee addressee)
    {
        Name = name;
        Addressee = addressee;
    }

    public string Name { get; }
    public IAddressee Addressee { get; }

    public void SendToAddressee(Massage massage, Color color)
    {
        Addressee.SendMassage(massage, color);
    }

    public bool SendToAddresseeWithFilter(Massage massage, Color color, int level)
    {
        return Addressee.SendMassageFilter(massage, color, level);
    }
}