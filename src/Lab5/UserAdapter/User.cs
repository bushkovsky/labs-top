using Application.DomainModels;
using Application.Ports;

namespace UserAdapter;

public class User : IUserPort
{
    public User(UserAccountRepository rep, IAccount account)
    {
        Rep = rep;
        Account = account;
    }

    public UserAccountRepository Rep { get; private set; }
    public IAccount Account { get; private set; }

    public int CheckAccountBalance()
    {
        return Account.CheckAccountBalance();
    }

    public void DecreaseAccountBalance(int number)
    {
        Account.DecreaseAccountBalance(number);
    }

    public void IncreaseAccountBalance(int number)
    {
        Account.IncreaseAccountBalance(number);
    }

    public IList<string> CheckHistory()
    {
        return Account.CheckHistory();
    }
}