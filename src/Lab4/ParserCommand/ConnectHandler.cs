using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParserCommand;

public class ConnectHandler : CommandHendler
{
    public static string AddresseParce(string request)
    {
        var command = new List<string>(request.Split(' '));
        string result = string.Empty;
        for (int i = 1; i < command.Count - 1; i++)
        {
            result += command[1][i];
        }

        return result;
    }

    public override ICommand? HandleRequest(string request)
    {
        if (ParseRequest(request))
        {
            if (MarkDefine(request) == Marks.M && ModeDefine(request) == Modes.Local)
            {
                return new Connect(AddresseParce(request));
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
        return command[0] == "connect" && command[1][0] == '[' && command[1][command[1].Length - 1] == ']' &&
               command[2][0] == '[' && command[3][command[1].Length - 1] == ']';
    }

    private Modes? ModeDefine(string request)
    {
        var command = new List<string>(request.Split(' '));
        if (command.Count == 4)
        {
            return ModeRep.GetMode(command[3]);
        }

        return null;
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