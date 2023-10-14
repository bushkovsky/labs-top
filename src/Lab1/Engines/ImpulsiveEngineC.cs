using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class ImpulsiveEngineC : IImpulsiveEngine
{
    private const int FixSpeed = 55;
    private const int StartFuelConsumption = 10;
    private const int MassReverseCoefficient = 20;
    private int _distance;

    public ImpulsiveEngineC(int fuelVolume, int weight)
    {
        _distance = (fuelVolume / (weight / MassReverseCoefficient)) - StartFuelConsumption;
    }

    public void Flight(PartRoute.SpacePartRoute partRoute, FuelTank fuelTank)
    {
        _distance = Start(fuelTank);
        _distance -= partRoute.Distance;
    }

    public void Flight(PartRoute.SpacePartRoute partRoute)
    {
        _distance -= partRoute.Distance;
    }

    public bool IsSuccessfulFlight(PartRoute.SpacePartRoute partRoute, FuelTank fuelTank)
    {
        return IsSuccessfulStart(fuelTank) && (partRoute.EnvironmentOfPart is Space
               && -_distance - partRoute.Distance >= 0);
    }

    public double FuelConsumption(PartRoute.SpacePartRoute partRoute, FuelTank? fuelTank)
    {
        if (fuelTank is not null)
        {
            return (partRoute.Distance / _distance) * fuelTank.FuelVolume;
        }

        return 0;
    }

    public int FlightTime(PartRoute.SpacePartRoute partRoute, FuelTank? fuelTank)
    {
        return _distance / FixSpeed;
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