using Application.Ports;

namespace CLI.Commands;

public class MakeNewAccount : ICommand
{
    public MakeNewAccount(IAdminPort port, int number, int pin)
    {
        Port = port;
        Number = number;
        Pin = pin;
    }

    public IAdminPort Port { get; private set; }
    public int Number { get; }
    public int Pin { get; }
    public string? CommandExecute()
    {
        Port.MakeNewAccount(Number, Pin);
        return "New account has been created";
    }
}