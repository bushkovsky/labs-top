namespace Application.Ports;

public interface IAdminPort : IUserPort
{
    public void MakeNewAccount(int number, int pin);
}