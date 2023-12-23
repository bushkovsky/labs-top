namespace Application.DomainModels;

public interface IAdminAccount : IAccount
{
    public void MakeNewAccount(int number, int pin);
}