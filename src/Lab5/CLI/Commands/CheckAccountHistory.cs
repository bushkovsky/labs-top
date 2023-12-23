using Application.Ports;

namespace CLI.Commands;

public class CheckAccountHistory : ICommand
{
    public CheckAccountHistory(IUserPort port)
    {
        Port = port;
    }

    public IUserPort Port { get; private set; }

    public string? CommandExecute()
    {
        string result = string.Empty;
        IList<string> history = Port.CheckHistory();
        foreach (string elementOfHistory in history)
        {
            result += elementOfHistory + '\n';
        }

        return result;
    }
}