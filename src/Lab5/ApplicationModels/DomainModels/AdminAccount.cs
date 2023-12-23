namespace Application.DomainModels;

public class AdminAccount : IAdminAccount
{
    public AdminAccount(int systemPassword)
    {
        SystemPassword = systemPassword;
    }

    public AdminAccount(int systemPassword, UserAccount account)
    {
        Account = account;
        SystemPassword = systemPassword;
    }

    public UserAccount? Account { get; private set; }
    public int SystemPassword { get; }
    public int CheckAccountBalance()
    {
        if (Account != null) return Account.Balance;
        return -1;
    }

    public void DecreaseAccountBalance(int number)
    {
        Account?.DecreaseAccountBalance(number);
    }

    public void IncreaseAccountBalance(int number)
    {
        Account?.IncreaseAccountBalance(number);
    }

    public IList<string> CheckHistory()
    {
        if (Account is not null)
        {
            return Account.CheckHistory();
        }

        return new List<string>();
    }

    public void MakeNewAccount(int number, int pin)
    {
        Account = new UserAccount(number, pin);
    }
}