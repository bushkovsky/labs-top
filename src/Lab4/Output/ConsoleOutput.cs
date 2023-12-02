using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Output;

public class ConsoleOutput : IOutput
{
    public void Write(string? result)
    {
        if (result is not null)
        {
            Console.WriteLine(result);
            return;
        }

        Console.WriteLine("error");
    }
}