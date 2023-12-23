namespace Application.DomainModels;

public interface IAccount
{
    public int CheckAccountBalance();
    public void DecreaseAccountBalance(int number);
    public void IncreaseAccountBalance(int number);
    public IList<string> CheckHistory();
}