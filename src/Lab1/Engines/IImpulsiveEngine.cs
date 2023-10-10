using Itmo.ObjectOrientedProgramming.Lab1.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public interface IImpulsiveEngine : IEngine
{
    public int Start(FuelTank fuelTank);
    public bool IsSuccessfulStart(FuelTank fuelTank);
    public double FuelConsumption(PartRoute.SpacePartRoute partRoute, FuelTank? fuelTank);
    public int FlightTime(PartRoute.SpacePartRoute partRoute, FuelTank fuelTank);
}