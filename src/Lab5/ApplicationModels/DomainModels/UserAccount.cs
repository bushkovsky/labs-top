namespace Application.DomainModels;

public class UserAccount : IAccount
{
    public UserAccount(int number, int pin)
    {
        Number = number;
        Pin = pin;
        Balance = 0;
        History = new List<string>();
        History.Add("Make new account: Welcome");
    }

    public IList<string> History { get; private set; }
    public int Number { get; }
    public int Pin { get; }
    public int Balance { get; private set; }

    public int CheckAccountBalance()
    {
        History.Add("Checking account balance" + Convert.ToString(Balance, 10));
        return Balance;
    }

    public void DecreaseAccountBalance(int number)
    {
        Balance -= number;
        History.Add("Decrease account balance: balance:" + Convert.ToString(Balance, 10) + " decrease number: " + Convert.ToString(Number, 10));
    }

    public void IncreaseAccountBalance(int number)
    {
        Balance += number;
        History.Add("Increase account balance: balance:" + Convert.ToString(Balance, 10) + " increase number: " + Convert.ToString(Number, 10));
    }

    public IList<string> CheckHistory()
    {
        History.Add("Checking history");
        return History;
    }
}