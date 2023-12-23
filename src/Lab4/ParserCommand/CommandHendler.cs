using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserCommand;

public class CommandHendler : IHandler
{
    private IHandler? _next;

    public MarkRepository MarkRep { get; } = new MarkRepository();
    public ModeRepository ModeRep { get; } = new ModeRepository();

    public void SetNext(IHandler? handler)
    {
        _next = handler;
    }

    public virtual ICommand? HandleRequest(string request)
    {
        _next?.HandleRequest(request);
        return null;
    }
}