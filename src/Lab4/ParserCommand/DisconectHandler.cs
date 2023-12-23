using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserCommand;

public class DisconectHandler : CommandHendler
{
    public override ICommand? HandleRequest(string request)
    {
        if (ParseRequest(request))
        {
            return new Disconnect();
        }
        else
        {
            base.HandleRequest(request);
        }

        return null;
    }

    private static bool ParseRequest(string request)
    {
        return request == "disconnect";
    }
}