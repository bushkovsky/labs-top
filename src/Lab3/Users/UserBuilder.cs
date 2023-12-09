using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class UserBuilder
{
    private IList<UserMassage> _massages = new List<UserMassage>();
    private string _firstName = " ";
    private string _sureName = " ";
    private string _city = " ";
    private string _street = " ";
    private int _house;
    private int _age;
    private string _birthPlace = " ";
    private string _sex = " ";
    private string _workingPosition = " ";

    public void FirstNameBuilder(string firstName)
    {
        _firstName = firstName;
    }

    public void SureNameBuilder(string sureName)
    {
        _sureName = sureName;
    }

    public void CityBuilder(string city)
    {
        _city = city;
    }

    public void StreetBuilder(string street)
    {
        _street = street;
    }

    public void BirthPlaceBuilder(string birthPlace)
    {
        _birthPlace = birthPlace;
    }

    public void SexBuilder(string sex)
    {
        _sex = sex;
    }

    public void WorkingPositionBuilder(string workingPosition)
    {
        _workingPosition = workingPosition;
    }

    public void HouseBuilder(int house)
    {
        _house = house;
    }

    public void AgeBuilder(int age)
    {
        _age = age;
    }

    public void AddItemBuilder(UserMassage userMassage)
    {
        _massages.Add(userMassage);
    }

    public User GetResult()
    {
        var result = new User();
        result.SetAge(_age);
        result.SetCity(_city);
        result.SetHouse(_house);
        result.SetSex(_sex);
        result.SetStreet(_street);
        result.SetBirthPlace(_birthPlace);
        result.SetFirstName(_firstName);
        result.SetSureName(_sureName);
        result.SetWorkingPosition(_workingPosition);

        return result;
    }
}