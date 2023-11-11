using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class GroupAddressee : IAddressee
{
    private IList<IAddressee> _addressees;

    public GroupAddressee(IList<IAddressee> addressees)
    {
        _addressees = addressees;
        OutputMassage = new Massage(" ", " ", -1);
    }

    public Massage OutputMassage { get; }

    public void LogAccess()
    {
        Console.WriteLine("List of adressees is processed");
    }

    public void ProcessedAddressees(Massage massage, Colors color)
    {
        LogAccess();
        foreach (IAddressee i in _addressees)
        {
            if (i is UserAddressee userAddressee)
            {
                userAddressee.AddMassage(massage);
            }

            if (i is DisplayAddressee displayAddressee)
            {
                var displayNewTextDriver = new DisplayNewTextDriver(displayAddressee.DisplayON);
                displayNewTextDriver.OutputOnDisplay(color);
            }

            if (i is Messenger messenger)
            {
                var massages = new List<Massage>();
                massages.Add(massage);

                messenger.PrintMassage(massages);
            }
        }
    }
}