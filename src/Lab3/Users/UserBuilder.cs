using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class UserBuilder
{
    public IList<UserMassage> Massages { get; private set; } = new List<UserMassage>();
    private string FirstName { get; set; } = " ";
    private string SureName { get; set; } = " ";
    private string City { get; set; } = " ";
    private string Street { get; set; } = " ";
    private int House { get; set; }
    private int Age { get; set; }
    private string BirthPlace { get; set; } = " ";
    private string Sex { get; set; } = " ";
    private string WorkingPosition { get; set; } = " ";
    private int Level { get; set; }

    public void FirstNameBuilder(string firstName)
    {
        FirstName = firstName;
    }

    public void SureNameBuilder(string sureName)
    {
        SureName = sureName;
    }

    public void CityBuilder(string city)
    {
        City = city;
    }

    public void StreetBuilder(string street)
    {
        Street = street;
    }

    public void BirthPlaceBuilder(string birthPlace)
    {
        BirthPlace = birthPlace;
    }

    public void SexBuilder(string sex)
    {
        Sex = sex;
    }

    public void WorkingPositionBuilder(string workingPosition)
    {
        WorkingPosition = workingPosition;
    }

    public void HouseBuilder(int house)
    {
        House = house;
    }

    public void AgeBuilder(int age)
    {
        Age = age;
    }

    public void LevelBuilder(int level)
    {
        Level = level;
    }

    public User GetResult()
    {
        var result = new User();
        result.SetAge(Age);
        result.SetCity(City);
        result.SetHouse(House);
        result.SetSex(Sex);
        result.SetStreet(Street);
        result.SetBirthPlace(BirthPlace);
        result.SetFirstName(FirstName);
        result.SetSureName(SureName);
        result.SetWorkingPosition(WorkingPosition);
        result.SetLevel(Level);

        return result;
    }
}