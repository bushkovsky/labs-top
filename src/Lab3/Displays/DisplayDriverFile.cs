using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class DisplayDriverFile : IDisplayDriver
{
    public Massage SetText(string title, string body, int level)
    {
        return new Massage(title, body, level);
    }

    public Color SetColor(int red, int green, int blue)
    {
        return new Color(red, green, blue);
    }

    public void ClearDisplay()
    {
        var writer = new FileStream(@"D:\output.txt", FileMode.Open);
        writer.SetLength(0);
        writer.Close();
    }

    public void Output(string text)
    {
        var writer = new StreamWriter(@"D:\output.txt");
        writer.Write(text);
        writer.Close();
    }
}