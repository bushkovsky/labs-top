using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class UserAddressee : IAddressee
{
    private User _user;
    public UserAddressee(User user, ILogger loggerUser)
    {
        _user = user;
        LoggerUser = loggerUser;
    }

    public ILogger LoggerUser { get; }

    public void SendMassage(Massage massage, Color color)
    {
        _user.AddMassage(massage);
    }

    public bool LevelFilter(int level, Massage massage)
    {
        return massage.RelevanceLevel <= level;
    }

    public bool SendMassageFilter(Massage massage, Color color, int level)
    {
        if (!LevelFilter(level, massage)) return false;
        SendMassage(massage, color);
        return true;
    }
}