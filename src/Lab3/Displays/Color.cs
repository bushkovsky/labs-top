namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public record Color
{
    public Color(int red, int green, int blue)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }

    public int Red { get; }
    public int Green { get; }
    public int Blue { get; }
}