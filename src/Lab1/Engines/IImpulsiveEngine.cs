using Itmo.ObjectOrientedProgramming.Lab1.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public interface IImpulsiveEngine
{
    public void Flight(PartRoute.SpacePartRoute partRoute, FuelTank fuelTank);
    public double FuelConsumption(PartRoute.SpacePartRoute partRoute, FuelTank? fuelTank);
    public int FlightTime(PartRoute.SpacePartRoute partRoute, FuelTank fuelTank);
    public bool IsSuccessfulFlight(PartRoute.SpacePartRoute partRoute, FuelTank fuelTank);
}