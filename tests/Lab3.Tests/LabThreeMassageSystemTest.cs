using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class LabThreeMassageSystemTest
{
    [Fact]
    public void TestUserUnread()
    {
        var userBuilder = new UserBuilder();
        userBuilder.AgeBuilder(20);
        userBuilder.CityBuilder("spb");
        userBuilder.SexBuilder("male");
        userBuilder.HouseBuilder(3);
        userBuilder.StreetBuilder("Lenin");
        userBuilder.BirthPlaceBuilder("Tokyo");
        userBuilder.FirstNameBuilder("Emin");
        userBuilder.SureNameBuilder("Begin");
        userBuilder.WorkingPositionBuilder("Mentor");
        User user = userBuilder.GetResult();

        var massage = new Massage("FIX", "my lab is good i think", 2);
        user.AddMassage(massage);
        Assert.Equal("Unread", user.Massages[0].ReadStatus);
    }

    [Fact]
    public void TestUserMarkMassage()
    {
        var userBuilder = new UserBuilder();
        userBuilder.AgeBuilder(20);
        userBuilder.CityBuilder("spb");
        userBuilder.SexBuilder("male");
        userBuilder.HouseBuilder(3);
        userBuilder.StreetBuilder("Lenin");
        userBuilder.BirthPlaceBuilder("Tokyo");
        userBuilder.FirstNameBuilder("Emin");
        userBuilder.SureNameBuilder("Begin");
        userBuilder.WorkingPositionBuilder("Mentor");
        User user = userBuilder.GetResult();

        var massage = new Massage("FIX", "my lab is good i think", 2);
        user.AddMassage(massage);
        Assert.Equal("Unread", user.Massages[0].ReadStatus);
        user.MarkMassage(user.Massages[0]);
        Assert.Equal("Read", user.Massages[0].ReadStatus);
    }

    [Fact]
    public void TestUserTryMarkMassage()
    {
        var userBuilder = new UserBuilder();
        userBuilder.AgeBuilder(20);
        userBuilder.CityBuilder("spb");
        userBuilder.SexBuilder("male");
        userBuilder.HouseBuilder(3);
        userBuilder.StreetBuilder("Lenin");
        userBuilder.BirthPlaceBuilder("Tokyo");
        userBuilder.FirstNameBuilder("Emin");
        userBuilder.SureNameBuilder("Begin");
        userBuilder.WorkingPositionBuilder("Mentor");
        User user = userBuilder.GetResult();

        var massage = new Massage("FIX", "my lab is good i think", 2);
        user.AddMassage(massage);
        Assert.Equal("Unread", user.Massages[0].ReadStatus);
        user.MarkMassage(user.Massages[0]);
        Assert.Equal("Read", user.Massages[0].ReadStatus);
        Assert.False(user.MarkMassage(user.Massages[0]));
    }

    [Fact]
    public void TestMessenger()
    {
        var massage = new Massage("FIX", "my lab is good i think", 2);
        Messenger mock = Substitute.For<Messenger>();

        var controller = new MessengerAddressee(mock, new Logger("Log access messenger"));
        controller.SendMassage(massage, new Color(5, 4, 7));
        Assert.Equal(" Massanger: " + massage.Title + "\n" + massage.Body, controller.Messenger.PrintMassage(massage));
    }

    [Fact]
    public void TesLogging()
    {
        var massage = new Massage("FIX", "my lab is good i think", 2);
        var messenger = new Messenger();
        ILogger mock = Substitute.For<ILogger>();
        var messengerAddressee = new MessengerAddressee(messenger, mock);
        messengerAddressee.SendMassage(massage, new Color(3, 5, 6));
        Assert.Single(mock.ReceivedCalls().Where(x => x.GetMethodInfo().Name == "LogAccess"));
    }

    [Fact]
    public void TestLevel()
    {
        var massage = new Massage("FIX", "my lab is good i think", 6);
        User mock = Substitute.For<User>();
        var controller = new UserAddressee(mock, new Logger("Log user access"));
        Assert.False(controller.SendMassageFilter(massage, new Color(3, 5, 6), 5));
    }
}