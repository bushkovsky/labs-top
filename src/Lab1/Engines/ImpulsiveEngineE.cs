using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.PartRoute;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class ImpulsiveEngineE : IImpulsiveEngine
{
    private const int StartFuelConsumption = 20;
    private const int MassReverseCoefficient = 20;
    private int _distance;

    public ImpulsiveEngineE(int fuelVolume, int weight)
    {
        _distance = ((int)System.Math.Exp(fuelVolume) - StartFuelConsumption) - (AccelerationCosts(fuelVolume) / (weight / MassReverseCoefficient));
    }

    public void Flight(SpacePartRoute partRoute)
    {
        _distance -= partRoute.Distance;
    }

    public void Flight(SpacePartRoute partRoute, FuelTank fuelTank)
    {
        _distance = Start(fuelTank);
        _distance -= partRoute.Distance;
    }

    public bool IsSuccessfulFlight(SpacePartRoute partRoute, FuelTank fuelTank)
    {
        return IsSuccessfulStart(fuelTank) && ((partRoute.EnvironmentOfPart is NitrineParticleNebulae ||
                                                partRoute.EnvironmentOfPart is Space)
                                               && _distance - partRoute.Distance >= 0);
    }

    public double FuelConsumption(SpacePartRoute partRoute, FuelTank? fuelTank)
    {
        if (fuelTank is not null)
        {
            double n = ((double)partRoute.Distance / (double)_distance) * (double)fuelTank.FuelVolume;
            return n;
        }

        return 0.0;
    }

    public int FlightTime(SpacePartRoute partRoute, FuelTank fuelTank)
    {
        return (int)((double)fuelTank.FuelVolume / FuelConsumption(partRoute, fuelTank));
    }

    private static int AccelerationCosts(int fuelVolume)
    {
        return (int)System.Math.Log(fuelVolume - StartFuelConsumption);
    }

    private static int Start(FuelTank fuelTank)
    {
        return fuelTank.FuelVolume - StartFuelConsumption;
    }

    private static bool IsSuccessfulStart(FuelTank fuelTank)
    {
        return fuelTank.FuelVolume >= StartFuelConsumption;
    }
}