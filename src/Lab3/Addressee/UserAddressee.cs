using Itmo.ObjectOrientedProgramming.Lab3.Massages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class UserAddressee : IAddressee
{
    private User _user;
    public UserAddressee(User user)
    {
        _user = user;
    }

    public void SendMassage(Massage massage)
    {
        _user.AddMassage(massage);
    }
}