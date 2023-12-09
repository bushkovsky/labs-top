using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Interactions;
using Itmo.ObjectOrientedProgramming.Lab4.ParserCommand;
using Xunit;
namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Lab4Tests
{
    [Fact]
    public void TestCommandOne()
    {
        var connectHandler = new ConnectHandler();
        Assert.Equal(new Connect("D:").GetType(), connectHandler.HandleRequest(@"connect [D:\\] [-m local]")?.GetType());
        Assert.Equal("D:", ConnectHandler.AddressParse(@"connect [D:\\] [-m local]"));
    }

    [Fact]
    public void TestCommandTwo()
    {
        var disconnectHandler = new DisconectHandler();
        Assert.Equal(new Disconnect().GetType(), disconnectHandler.HandleRequest("disconnect")?.GetType());
        if (disconnectHandler.HandleRequest("disconnect") is Disconnect disconnect)
        {
            var status = new StatusFileSystem(" ");
            Assert.Null(disconnect.CommandExecute(status));
        }
    }
}