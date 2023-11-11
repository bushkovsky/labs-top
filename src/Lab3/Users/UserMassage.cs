using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public record UserMassage : Massage
{
    public UserMassage(Massage massage, string readStatus)
        : base(massage.Title, massage.Body, massage.RelevanceLevel)
    {
        ReadStatus = readStatus;
    }

    public string ReadStatus { get; private set; }

    public void ChangeStatus()
    {
        ReadStatus = "Read";
    }

    public static int Comparelevel(UserMassage userMassageFirst, UserMassage userMassageSecond)
    {
        return userMassageFirst.RelevanceLevel - userMassageSecond.RelevanceLevel;
    }
}