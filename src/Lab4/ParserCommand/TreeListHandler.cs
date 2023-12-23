using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserCommand;

public class TreeListHandler : CommandHendler
{
    public override ICommand? HandleRequest(string request)
    {
        if (ParseRequest(request))
        {
            if (MarkDefine(request) == Marks.D)
            {
                return new TreeList(ParseDepth(request));
            }
        }
        else
        {
            base.HandleRequest(request);
        }

        return null;
    }

    private static int ParseDepth(string request)
    {
        var command = new List<string>(request.Split(' '));
        string result = string.Empty;
        for (int i = 0; i < command.Count - 1; i++)
        {
            result += command[3][i];
        }

        int res;
        if (int.TryParse(result, out res))
        {
            return res;
        }
        else
        {
            return -1;
        }
    }

    private static bool ParseRequest(string request)
    {
        var command = new List<string>(request.Split(' '));
        if (command.Count == 4)
        {
            return command[0] == "tree" && command[1] == "list" && command[2] == "{-d"
                   && command[3][command.Count - 1] == '}';
        }

        return false;
    }

    private Marks? MarkDefine(string request)
    {
        var command = new List<string>(request.Split(' '));
        if (command.Count == 4)
        {
            return MarkRep.GetMark(command[2]);
        }

        return null;
    }
}