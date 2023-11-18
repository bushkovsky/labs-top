using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplay
{
    public Massage OutputMassage { get; }
    public void OutputOnDisplay(int red, int green, int blue);
    public void UpdateMassage(Massage massage);
}