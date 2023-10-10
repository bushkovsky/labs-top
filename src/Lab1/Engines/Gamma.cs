namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class Gamma : JumpEngine
{
    public Gamma(int fuelVolume, int mass)
        : base(QuadraticDistanceCalculation(fuelVolume, mass))
    { }

    private static int QuadraticDistanceCalculation(int volume, int mass)
    {
        return volume * volume / (mass / 20);
    }
}