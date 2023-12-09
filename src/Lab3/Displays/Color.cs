namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public record Color
{
    public Color(int red, int green, int blue)
    {
        Red = (byte)red;
        Green = (byte)green;
        Blue = (byte)blue;
    }

    public byte Red { get; }
    public byte Green { get; }
    public byte Blue { get; }
}