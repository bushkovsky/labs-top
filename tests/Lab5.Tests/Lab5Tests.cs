using Application.DomainModels;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Lab5Tests
{
    [Fact]
    public void IncAccountbalance()
    {
        var adminAccount = new AdminAccount(10, new UserAccount(10, 10));
        adminAccount.IncreaseAccountBalance(5);
        Assert.Equal(5, adminAccount.CheckAccountBalance());
    }

    [Fact]
    public void DecAccountbalance()
    {
        var adminAccount = new AdminAccount(10, new UserAccount(10, 10));
        adminAccount.IncreaseAccountBalance(5);
        adminAccount.DecreaseAccountBalance(3);
        Assert.Equal(2, adminAccount.CheckAccountBalance());
    }

    [Fact]
    public void CheckBalance()
    {
        var adminAccount = new AdminAccount(10, new UserAccount(10, 10));
        Assert.Equal(0, adminAccount.CheckAccountBalance());
    }
}