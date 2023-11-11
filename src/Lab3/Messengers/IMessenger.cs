using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public interface IMessenger
{
    public string PrintMassage(IEnumerable<Massage> massages);
}