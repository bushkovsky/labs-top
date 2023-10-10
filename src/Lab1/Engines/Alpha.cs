namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class Alpha : JumpEngine
{
    public Alpha(int fuelVolume, int mass)
        : base(LinearDistanceCalculation(fuelVolume, mass))
    { }

    private static int LinearDistanceCalculation(int volume, int mass)
    {
        return 2 * volume / (mass / 20);
    }
}