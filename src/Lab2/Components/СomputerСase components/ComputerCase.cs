namespace Itmo.ObjectOrientedProgramming.Lab2.Components.СomputerСasecomponents;

public class ComputerCase : IComponent
{
    public ComputerCase(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public int GraficCardWidth { get; private set; }
    public int GraficCardLength { get; private set; }
    public string FormFactor { get; private set; } = " ";
    public int Width { get; private set; }
    public int Length { get; private set; }
    public int Height { get; private set; }

    public void SetGraficCardWidth(int width)
    {
        GraficCardWidth = width;
    }

    public void SetGraficCardLength(int length)
    {
        GraficCardLength = length;
    }

    public void SetFormFactor(string formFactor)
    {
        FormFactor = formFactor;
    }

    public void SetWidth(int width)
    {
        Width = width;
    }

    public void SetLength(int length)
    {
        Length = length;
    }

    public void SetHeight(int height)
    {
        Height = height;
    }
}