namespace Itmo.ObjectOrientedProgramming.Lab1.Fuel;

public class FuelTank
{
    public FuelTank(int fuetlvolume)
    {
        FuelVolume = fuetlvolume;
    }

    public int FuelVolume { get; private set; }

    public void DecreaseFuetlVolume(int decrease)
    {
        FuelVolume -= decrease;
    }

    public void ChangeFuelVolume(int change)
    {
        FuelVolume = change;
    }
}