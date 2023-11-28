using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplayDriver
{
    public Massage SetText(string title, string body, int level);

    public Color SetColor(int red, int green, int blue);

    public void ClearDisplay();

    public void Output(string text);
}