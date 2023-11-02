namespace Itmo.ObjectOrientedProgramming.Lab2.Components.СomputerСasecomponents;

public class ComputerCaseBuilder
{
    /*
     *  public string Name { get; }
    public int GraficCardWidth { get; private set; }
    public int GraficCardLength { get; private set; }
    public string FormFactor { get; private set; } = " ";
    public int Width { get; private set; }
    public int Length { get; private set; }
    public int Height { get; private set; }
     */

    private ComputerCase _computerCase = new ComputerCase(" ");

    public ComputerCaseBuilder(string productName)
    {
        Reset(productName);
    }

    public void Reset(string productName)
    {
        _computerCase = new ComputerCase(productName);
    }

    public void GraficCardWidthBuild(int width)
    {
        _computerCase.SetGraficCardWidth(width);
    }

    public void GraficCardLength(int lenght)
    {
        _computerCase.SetGraficCardLength(lenght);
    }

    public void FormFactorBuild(string formFactor)
    {
        _computerCase.SetFormFactor(formFactor);
    }

    public void WidthBuild(int width)
    {
        _computerCase.SetWidth(width);
    }

    public void LengthBuild(int length)
    {
        _computerCase.SetLength(length);
    }

    public void HeightBuild(int height)
    {
        _computerCase.SetHeight(height);
    }

    public void Debuild(ComputerCase computerCase, string newName)
    {
        Reset(newName);
        GraficCardWidthBuild(computerCase.GraficCardWidth);
        GraficCardLength(computerCase.GraficCardLength);
        FormFactorBuild(computerCase.FormFactor);
        WidthBuild(computerCase.Width);
        LengthBuild(computerCase.Length);
        HeightBuild(computerCase.Height);
    }

    public ComputerCase GetComputerCase()
    {
        ComputerCase result = _computerCase;
        Reset(" ");
        return result;
    }
}