using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class Omega : JumpEngine
{
    public Omega(int fuelVolume, int mass)
        : base(LogaritmicDistanceCalculation(fuelVolume, mass))
    { }

    private static int LogaritmicDistanceCalculation(int volume, int mass)
    {
        return 5 * volume * (int)Math.Log(volume) / (mass / 20);
    }
}