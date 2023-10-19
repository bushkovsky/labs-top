namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class Alpha : JumpEngine
{
    private const int VolumeCoefficient = 2;
    private const int MassReverseCoefficient = 20;
    public Alpha(int fuelVolume, int mass)
        : base(LinearDistanceCalculation(fuelVolume, mass))
    { }

    private static int LinearDistanceCalculation(int volume, int mass)
    {
        return VolumeCoefficient * volume / (mass / MassReverseCoefficient);
    }
}