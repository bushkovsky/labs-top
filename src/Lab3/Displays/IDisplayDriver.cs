using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplayDriver
{
    public void SetColor(int red, int green, int blue);

    public void ClearDisplay();

    public void Output(Massage massage);
}