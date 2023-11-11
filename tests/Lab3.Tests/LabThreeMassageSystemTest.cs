using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
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
        userBuilder.LevelBuilder(4);
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
        userBuilder.LevelBuilder(4);
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
        userBuilder.LevelBuilder(4);
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
        var massages = new List<Massage>();
        massages.Add(massage);
        Messenger mock = Substitute.For<Messenger>();

        // moq.Setup(x => x.PrintMassage(massages)).Returns("Massanger: " + massage.Title + "\n" + massage.Body);
        var controller = new MessengerAddressee(mock);
        Assert.Equal(" Massanger: " + massage.Title + "\n" + massage.Body, controller.PrintMassage(massages));
    }

    [Fact]
    public void TesLogging()
    {
        var massage = new Massage("FIX", "my lab is good i think", 2);
        var massages = new List<Massage>();
        massages.Add(massage);
        var messenger = new Messenger();
        MessengerAddressee mock = Substitute.For<MessengerAddressee>(messenger);
        mock.PrintMassage(massages);
        mock.LogAccess();
        IEnumerable enumerable = mock.ReceivedCalls();
        Assert.Empty(mock.ReceivedCalls().Where(x => x.GetMethodInfo().Name == "LogAccess"));
    }

    [Fact]
    public void TestLevel()
    {
        var massage = new Massage("FIX", "my lab is good i think", 6);
        var massages = new List<Massage>();
        massages.Add(massage);
        User mock = Substitute.For<User>();
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
        userBuilder.LevelBuilder(4);

        // mock = userBuilder.GetResult();
        var controller = new UserAddressee(mock, 2);
        Assert.False(controller.AddMassage(massage));
    }
}