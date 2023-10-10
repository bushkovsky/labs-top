using Itmo.ObjectOrientedProgramming.Lab1.PartRoute;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips;

public interface ISpaceShip
{
    public (bool CrewDeath, bool ShipIsDestroy, (bool ShipGotLost, (double Time, int FuelConsumedVolume) Data) Succes) Flight(SpacePartRoute[] spaceRoute);
}