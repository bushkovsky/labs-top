using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class JumpEngine : IEngine
{
    private const int FixSpeed = 75;
    private int _distance;

    protected JumpEngine(int distanceCalculationResult)
    {
        _distance = distanceCalculationResult;
        StartDistance = _distance;
    }

    public int StartDistance { get; }

    public void Flight(PartRoute.SpacePartRoute partRoute)
    {
        _distance -= partRoute.Distance;
    }

    public bool IsSuccessfulFlight(PartRoute.SpacePartRoute partRoute)
    {
        return _distance - partRoute.Distance >= 0 && partRoute.EnvironmentOfPart is NebulaeOfIncreasedDensityOfSpace;
    }

    public double FlightTime()
    {
        return (double)_distance / (double)FixSpeed;
    }

    public int FuelConsumption(PartRoute.SpacePartRoute partRoute, FuelTank? fuelTank)
    {
        if (fuelTank is not null)
        {
            return (partRoute.Distance / _distance) * fuelTank.FuelVolume;
        }

        return 0;
    }
}