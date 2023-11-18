namespace Itmo.ObjectOrientedProgramming.Lab2.Components.GraficCardcomponents;

public interface IGraficCardBuilder
{
    public void Reset(string productName);

    public void HeightCardBuild(int height);

    public void WidthCardBuild(int width);

    public void VersionPciEBuild(int version);

    public void PowerBuild(int power);

    public void ChipFrequencyBuild(int chipFrequency);

    public void Debuild(GraficCard graficCard, string newName);

    public GraficCard GetGraficCard();
}