using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;

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

    public void SendToAddressee(Massage massage, Colors color)
    {
        if (Addressee is UserAddressee userAddressee)
        {
            userAddressee.AddMassage(massage);
        }

        if (Addressee is DisplayAddressee displayAddressee)
        {
            var displayNewTextDriver = new DisplayNewTextDriver(displayAddressee.DisplayON);
            displayNewTextDriver.OutputOnDisplay(color);
        }

        if (Addressee is Messenger messenger)
        {
            var massages = new List<Massage>();
            massages.Add(massage);

            messenger.PrintMassage(massages);
        }
    }
}