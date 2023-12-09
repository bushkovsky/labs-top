using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class LevelFilterAddressee : IAddressee
{
    private int _level;
    private IAddressee _addressee;

    public LevelFilterAddressee(int level, IAddressee addressee)
    {
        _level = level;
        _addressee = addressee;
    }

    public void SendMassage(Massage massage)
    {
        if (massage.RelevanceLevel <= _level)
        {
            _addressee.SendMassage(massage);
        }
    }
}