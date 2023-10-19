using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.PartRoute;
using Itmo.ObjectOrientedProgramming.Lab1.Route;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Dto;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service;

public class ProcessingService
{
    private SpaceShip _ship;
    private SpaceRoute _spaceRoute;

    public ProcessingService(SpaceShip ship, SpaceRoute spaceRoute)
    {
        _ship = ship;
        _spaceRoute = spaceRoute;
    }

    public ResultDto Flight()
    {
        var flightResult = new ResultDto(true, true, true, 0, 0);
        for (int i = 0; i < _spaceRoute.Route.Count; i++)
        {
            ResultFLightDto resultShipGotLost = FlightTrough(_spaceRoute.Route[i]);
            flightResult.ShipGotLost &= resultShipGotLost.Result;
            flightResult.Time += resultShipGotLost.Time;
            flightResult.FuelConsumedVolume += resultShipGotLost.FuelConsuption;

            foreach (IObstacles a in _spaceRoute.Route[i].EnvironmentOfPart.EnvironmentObstacles)
            {
                if (a is IPhysicalObstacle) flightResult.ShipIsDestroy &= ArmourDamageGet(a);
                if (a is IPhotonObstacle) flightResult.CrewDeath &= AntimatterDamageGet(a);
            }
        }

        return flightResult;
    }

    public double ShipFuelConsumption(SpacePartRoute partRoute)
    {
        return _ship.ImpulsiveEngine.FuelConsumption(partRoute, _ship.ShuttleFuelTankActivePlasma);
    }

    private bool AntimatterDamageGet(IObstacles obstacle)
    {
        bool result = true;
        for (int j = 0; j < obstacle.Count; j++)
        {
            if (_ship.Deflector is not null)
            {
                _ship.GetDamageAntimatterFlares(obstacle);
                result &= _ship.Deflector.ModificationIsAlive() ||
                          obstacle.Count == 0;
                if (!result)
                {
                    return result;
                }
            }
            else
            {
                result &= obstacle.Count == 0;
                return result;
            }
        }

        return result;
    }

    private bool ShipIsAlive()
    {
        return _ship.SpaceShipHull.IsAlive();
    }

    private bool ArmourDamageGet(IObstacles obstacle)
    {
        int i = 0;
        while (_ship.Deflector is not null && i < obstacle.Count)
        {
            _ship.ArmourGetDamage(_ship.Deflector, obstacle);
            i++;
        }

        while (_ship.Deflector is null && _ship.SpaceShipHull.IsAlive() && i - 1 < obstacle.Count)
        {
            _ship.ArmourGetDamage(_ship.SpaceShipHull, obstacle);
            i++;
        }

        return ShipIsAlive();
    }

    private ResultFLightDto FlightTrough(SpacePartRoute partRoute)
    {
        if (partRoute.EnvironmentOfPart is NebulaeOfIncreasedDensityOfSpace)
            return _ship.FlightTroughNebulaeOfIncreasedDensityOfSpace(partRoute);
        return _ship.FlightThroughEnvironment(partRoute);
    }
}