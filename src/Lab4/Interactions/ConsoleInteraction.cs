using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Output;
using Itmo.ObjectOrientedProgramming.Lab4.ParserCommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interactions;

public static class ConsoleInteraction
{
   private const string Stop = "-";
   public static StatusFileSystem Status { get; } = new StatusFileSystem(null);
   public static ConsoleOutput OutputToConsole { get; } = new ConsoleOutput();

   public static void Start()
   {
      var command1 = new ConnectHandler();
      var command2 = new DisconectHandler();
      command1.SetNext(command2);
      var command3 = new FileCopyHandler();
      command2.SetNext(command3);
      var command4 = new FileDeleteHandler();
      command3.SetNext(command4);
      var command5 = new FileMoveHandler();
      command4.SetNext(command5);
      var command6 = new FileRenameHandler();
      command5.SetNext(command6);
      var command7 = new FileShowHandler();
      command6.SetNext(command7);
      var command8 = new TreeGoToHandler();
      command7.SetNext(command8);
      var command9 = new TreeListHandler();
      command8.SetNext(command9);
      command9.SetNext(null);

      while (Console.ReadLine() != Stop)
      {
         string? command = Console.ReadLine();
         if (command != null)
         {
            ICommand? commandSystem = command1.HandleRequest(command);
            if (commandSystem != null) OutputToConsole.Write(commandSystem.CommandExecute(Status));
            else OutputToConsole.Write("error");
         }
      }
   }
}