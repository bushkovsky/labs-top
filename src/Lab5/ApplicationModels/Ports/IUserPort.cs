namespace Application.Ports;

public interface IUserPort
{
    public int CheckAccountBalance();
    public void DecreaseAccountBalance(int number);
    public void IncreaseAccountBalance(int number);
    public IList<string> CheckHistory();
}