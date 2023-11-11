using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class UserAddressee : IAddressee, IUser
{
    private User _user;
    private int _level;
    public UserAddressee(User user, int level)
    {
        _user = user;
        _level = level;
    }

    public void LogAccess()
    {
        Console.WriteLine("Proxy: User get massage ");
    }

    public bool AddMassage(Massage massage)
    {
        if (massage.RelevanceLevel > _level)
        {
            return false;
        }

        LogAccess();
        return _user.AddMassage(massage);
    }

    public void SortMassages()
    {
        var tmpMassages = _user.Massages.ToList();

        tmpMassages.Sort(UserMassage.Comparelevel);

        _user.SetMassages(tmpMassages);
    }
}