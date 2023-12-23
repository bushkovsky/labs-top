using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserCommand;

public class FileShowHandler : CommandHendler
{
    public override ICommand? HandleRequest(string request)
    {
        if (ParseRequest(request))
        {
            if (ModeDefine(request) == Modes.Console && MarkDefine(request) == Marks.M)
            {
                return new FileShow(ParsePath(request));
            }
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
        if (command.Count == 5)
        {
            return command[0] == "file" && command[1] == "show" && command[2][0] == '[' &&
                   command[2][command.Count - 1] == ']'
                   && command[3][0] == '{' && command[4][command.Count - 1] == '}';
        }

        return false;
    }

    private static string ParsePath(string request)
    {
        var command = new List<string>(request.Split(' '));
        string result = string.Empty;
        for (int i = 1; i < command.Count - 1; i++)
        {
            result += command[2][i];
        }

        return result;
    }

    private Modes? ModeDefine(string request)
    {
        var command = new List<string>(request.Split(' '));
        if (command.Count == 5)
        {
            return ModeRep.GetMode(command[4]);
        }

        return null;
    }

    private Marks? MarkDefine(string request)
    {
        var command = new List<string>(request.Split(' '));
        if (command.Count == 5)
        {
            return MarkRep.GetMark(command[3]);
        }

        return null;
    }
}