namespace Itmo.ObjectOrientedProgramming.Lab2.Components.GraficCardcomponents;

public class GraficCardBuilder : IGraficCardBuilder
{
    private GraficCard _graficCard = new GraficCard(" ");

    public GraficCardBuilder(string productName)
    {
       Reset(productName);
    }

    public void Reset(string productName)
    {
        _graficCard = new GraficCard(productName);
    }

    public void HeightCardBuild(int height)
    {
        _graficCard.SetHeightCard(height);
    }

    public void WidthCardBuild(int width)
    {
        _graficCard.SetWidthCard(width);
    }

    public void VersionPciEBuild(int version)
    {
        _graficCard.SetVersionPciE(version);
    }

    public void PowerBuild(int power)
    {
        _graficCard.SetPower(power);
    }

    public void ChipFrequencyBuild(int chipFrequency)
    {
        _graficCard.SetChipFrequency(chipFrequency);
    }

    public void Debuild(GraficCard graficCard, string newName)
    {
        Reset(newName);
        HeightCardBuild(graficCard.HeightCard);
        WidthCardBuild(graficCard.WidthCard);
        VersionPciEBuild(graficCard.VersionPciE);
        ChipFrequencyBuild(graficCard.ChipFrequency);
    }

    public GraficCard GetGraficCard()
    {
        GraficCard result = _graficCard;
        Reset(" ");
        return result;
    }
}