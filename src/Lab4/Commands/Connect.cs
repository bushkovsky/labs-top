using Itmo.ObjectOrientedProgramming.Lab4.Interactions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class Connect : ICommand
{
    public Connect(string address)
    {
        Address = address;
    }

    public string Address { get; }
    public string? CommandExecute(StatusFileSystem status)
    {
        return Address;
    }
}