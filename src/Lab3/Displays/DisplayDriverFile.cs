using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Massages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class DisplayDriverFile : IDisplayDriver
{
    private Color _color = new Color(0, 0, 0);

    public void SetColor(int red, int green, int blue)
    {
        _color = new Color(red, green, blue);
    }

    public void ClearDisplay()
    {
        var writer = new FileStream(@"D:\output.txt", FileMode.Open);
        writer.SetLength(0);
        writer.Close();
    }

    public void Output(Massage massage)
    {
        string text = Crayon.Output.Rgb(_color.Red, _color.Blue, _color.Green).Text(" Massanger: " + massage.Title + "\n" + massage.Body);
        var writer = new StreamWriter(@"D:\output.txt");
        writer.Write(text);
        writer.Close();
    }
}