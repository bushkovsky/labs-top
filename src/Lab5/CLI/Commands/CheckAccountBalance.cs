using Application.Ports;

namespace CLI.Commands;

public class CheckAccountBalance : ICommand
{
    public CheckAccountBalance(IUserPort port)
    {
        Port = port;
    }

    public IUserPort Port { get; private set; }
    public string? CommandExecute()
    {
        return "Check Balance:" + Convert.ToString(Port.CheckAccountBalance(), 10);
    }
}