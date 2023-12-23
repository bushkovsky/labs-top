using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserCommand;

public class FileMoveHandler : CommandHendler
{
    public override ICommand? HandleRequest(string request)
    {
        if (ParseRequest(request))
        {
            return new FileMove(ParseSource(request), ParseDestination(request));
        }
        else
        {
            base.HandleRequest(request);
        }

        return null;
    }

    private static bool ParseRequest(string request)
    {
        var command = new List<string>(request.Split(' '));
        if (command.Count == 4)
        {
            return command[0] == "file" && command[1] == "show" && command[2][0] == '[' &&
                   command[2][command.Count - 1] == ']'
                   && command[3][0] == '[' && command[3][command.Count - 1] == ']';
        }

        return false;
    }

    private static string ParseSource(string request)
    {
        var command = new List<string>(request.Split(' '));
        string result = string.Empty;
        for (int i = 1; i < command.Count - 1; i++)
        {
            result += command[2][i];
        }

        return result;
    }

    private static string ParseDestination(string request)
    {
        var command = new List<string>(request.Split(' '));
        string result = string.Empty;
        for (int i = 1; i < command.Count - 1; i++)
        {
            result += command[3][i];
        }

        return result;
    }
}