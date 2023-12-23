using Application.DomainModels;
using Application.Ports;
using DataAccess.Repositories;

namespace AdminAdapter;

public class Admin : IAdminPort
{
    public Admin(AdminAccountRepository rep, IAdminAccount account)
    {
        Rep = rep;
        Account = account;
    }

    public AdminAccountRepository Rep { get; private set; }
    public IAdminAccount Account { get; private set; }

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

    public void MakeNewAccount(int number, int pin)
    {
        Account.MakeNewAccount(number, pin);
    }
}