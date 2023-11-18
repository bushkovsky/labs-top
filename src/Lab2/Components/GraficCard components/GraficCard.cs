namespace Itmo.ObjectOrientedProgramming.Lab2.Components.GraficCardcomponents;

public class GraficCard : IComponent
{
    public GraficCard(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public int HeightCard { get; private set; }
    public int WidthCard { get; private set; }
    public int VersionPciE { get; private set; }
    public int ChipFrequency { get; private set; }

    public int Power { get; private set; }

    public void SetHeightCard(int heightCard)
    {
        HeightCard = heightCard;
    }

    public void SetPower(int power)
    {
        Power = power;
    }

    public void SetWidthCard(int widthCard)
    {
        WidthCard = widthCard;
    }

    public void SetVersionPciE(int version)
    {
        VersionPciE = version;
    }

    public void SetChipFrequency(int chipFrequency)
    {
        ChipFrequency = chipFrequency;
    }
}