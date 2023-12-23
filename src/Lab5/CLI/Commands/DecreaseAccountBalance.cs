using Application.Ports;

namespace CLI.Commands;

public class DecreaseAccountBalance : ICommand
{
    public DecreaseAccountBalance(IUserPort port, int number)
    {
        Port = port;
        Number = number;
    }

    public IUserPort Port { get; private set; }
    public int Number { get; }

    public string? CommandExecute()
    {
        Port.DecreaseAccountBalance(Number);
        return "Your money: " + Convert.ToString(Number, 10);
    }
}