using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User : IUser
{
    public IList<UserMassage> Massages { get; private set; } = new List<UserMassage>();
    public string FirstName { get; private set; } = string.Empty;
    public string SureName { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string Street { get; private set; } = string.Empty;
    public int House { get; private set; }
    public int Age { get; private set; }
    public string BirthPlace { get; private set; } = string.Empty;
    public string Sex { get; private set; } = string.Empty;
    public string WorkingPosition { get; private set; } = string.Empty;

    public void AddMassage(Massage massage)
    {
        var userMassage = new UserMassage(massage, "Unread");
        Massages.Add(userMassage);
    }

    public void SetMassages(IList<UserMassage> massages)
    {
        Massages = massages;
    }

    public bool MarkMassage(UserMassage userMassage)
    {
        if (Massages.Contains(userMassage) && userMassage.ReadStatus == "Unread")
        {
            Massages[Massages.IndexOf(userMassage)].ChangeStatus();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetFirstName(string firstName)
    {
        FirstName = firstName;
    }

    public void SetSureName(string sureName)
    {
        SureName = sureName;
    }

    public void SetCity(string city)
    {
        City = city;
    }

    public void SetStreet(string street)
    {
        Street = street;
    }

    public void SetBirthPlace(string birthPlace)
    {
        BirthPlace = birthPlace;
    }

    public void SetSex(string sex)
    {
        Sex = sex;
    }

    public void SetWorkingPosition(string workingPosition)
    {
        WorkingPosition = workingPosition;
    }

    public void SetHouse(int house)
    {
        House = house;
    }

    public void SetAge(int age)
    {
        Age = age;
    }
}