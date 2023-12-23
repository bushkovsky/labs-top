using Application.Ports;

namespace CLI.Commands;

public class IncreaseAccountBalance : ICommand
{
    public IncreaseAccountBalance(IUserPort port, int number)
    {
        Port = port;
        Number = number;
    }

    public IUserPort Port { get; private set; }
    public int Number { get; }

    public string? CommandExecute()
    {
        Port.IncreaseAccountBalance(Number);
        return "Your money in account: " + Convert.ToString(Number, 10);
    }
}