using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserCommand;

public interface IHandler
{
    public void SetNext(IHandler handler);
    public ICommand? HandleRequest(string request);
}