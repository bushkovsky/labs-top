using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.PartRoute;
using Itmo.ObjectOrientedProgramming.Lab1.ShipArmour;
using Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips;

public class SpaceShip : ISpaceShip
{
    private IImpulsiveEngine _impulsiveEngine;
    private JumpEngine? _jumpEngine;

    private IDeflector? _deflector;
    private IArmour _spaceShipHull;

    private FuelTank? shuttleFuelTankActivePlasma;
    private FuelTank? shuttleFuelTankGravitonMatter;

    private bool _antinitrineEmitter;

    protected SpaceShip(FuelTank? shuttleFuelTankActivePlasma, FuelTank? shuttleFuelTankGravitonMatter, IImpulsiveEngine impulsiveEngine, JumpEngine? jumpEngine, IDeflector? deflector, IArmour spaceShipHull, bool antinitrineEmitter)
    {
        this.shuttleFuelTankActivePlasma = shuttleFuelTankActivePlasma;
        this.shuttleFuelTankGravitonMatter = shuttleFuelTankGravitonMatter;
        _impulsiveEngine = impulsiveEngine;
        _jumpEngine = jumpEngine;
        _deflector = deflector;
        _spaceShipHull = spaceShipHull;
        _antinitrineEmitter = antinitrineEmitter;
        StartDistance = jumpEngine?.StartDistance ?? 0;
    }

    public int StartDistance { get; }

    public IArmour? SpaceShipHull => _spaceShipHull;

    public (bool, bool, (bool, (double, int))) Flight(SpacePartRoute[] spaceRoute)
    {
        (bool, bool, (bool, (double, int))) flightResult = (true, true, (true, (0, 0)));
        for (int i = 0; i < spaceRoute.Length; i++)
        {
            flightResult.Item1 = flightResult.Item1 && AntimatterFlaresDamage(spaceRoute[i]);
            flightResult.Item2 = flightResult.Item2 && ArmourDamage(spaceRoute[i]);
            flightResult.Item3.Item1 = flightResult.Item3.Item1 && FlightTrough(spaceRoute[i]).CheckFlight;
            flightResult.Item3.Item2.Item1 += FlightTrough(spaceRoute[i]).Succes.Time;
            flightResult.Item3.Item2.Item2 += FlightTrough(spaceRoute[i]).Succes.FuelConsumedVolume;
        }

        return flightResult;
    }

    public double ShipFuelConsumption(SpacePartRoute partRoute)
    {
        return _impulsiveEngine.FuelConsumption(partRoute, shuttleFuelTankActivePlasma);
    }

    private void ArmourGetDamage(IArmour armour, SpacePartRoute partRoute)
    {
        for (int i = 0; i < partRoute.EnvironmentOfPart.ObstaclesCount(); i++)
        {
            if (!_antinitrineEmitter && partRoute.EnvironmentOfPart.GetObstacleByIndex(i) is SpaceWhale) armour.GetDamage(partRoute.EnvironmentOfPart.GetObstacleByIndex(i));
        }
    }

    private bool ShipIsAlive()
    {
        return _spaceShipHull.IsAlive();
    }

    private bool ArmourDamage(SpacePartRoute partRoute)
    {
        if (_deflector is not null)
        {
            ArmourGetDamage(_deflector, partRoute);

            if (!_deflector.IsAlive())
            {
                _deflector = null;
            }
        }

        if (_deflector is null && _spaceShipHull is not null)
        {
            ArmourGetDamage(_spaceShipHull, partRoute);
        }

        return ShipIsAlive();
    }

    private bool AntimatterFlaresDamage(SpacePartRoute partRoute)
    {
        bool result = true;
        for (int i = 0; i < partRoute.EnvironmentOfPart.PhotonObstaclesCount(); i++)
        {
            for (int j = 0; j < partRoute.EnvironmentOfPart.GetPhotonObstacleByIndex(i)?.Count; j++)
            {
                if (_deflector is not null)
                {
                    _deflector.GetDamage(partRoute.EnvironmentOfPart.GetPhotonObstacleByIndex(i));

                    if (!(_deflector.ModificationIsAlive() ||
                          partRoute.EnvironmentOfPart.GetPhotonObstacleByIndex(i)?.Count == 0))
                    {
                        _deflector.DestroyModification();
                    }

                    result &= _deflector.ModificationIsAlive() ||
                              partRoute.EnvironmentOfPart.GetPhotonObstacleByIndex(i)?.Count == 0;

                    if (!result) return result;
                }
                else
                {
                    result &= partRoute.EnvironmentOfPart.GetPhotonObstacleByIndex(i)?.Count == 0;
                    return result;
                }
            }
        }

        return result;
    }

    private (bool CheckFlight, (double Time, int FuelConsumedVolume) Succes) FlightTroughNebulaeOfIncreasedDensityOfSpace(SpacePartRoute partRoute)
    {
        if (_jumpEngine is not null)
        {
            _jumpEngine.Flight(partRoute);
            if (_jumpEngine.IsSuccessfulFlight(partRoute))
            {
                shuttleFuelTankGravitonMatter?.DecreaseFuetlVolume(
                        _jumpEngine.FuelConsumption(partRoute, shuttleFuelTankGravitonMatter));

                return (true,
                    (_jumpEngine.FlightTime(), _jumpEngine.FuelConsumption(partRoute, shuttleFuelTankGravitonMatter)));
            }
        }

        return (false, (0, 0));
    }

    private (bool CheckFlight, (int Time, int FuelConsumedVolume) Succes) FlightThroughEnvironment(SpacePartRoute partRoute)
    {
        if (shuttleFuelTankActivePlasma is not null && _impulsiveEngine.IsSuccessfulFlight(partRoute, shuttleFuelTankActivePlasma))
        {
            _impulsiveEngine.Flight(partRoute, shuttleFuelTankActivePlasma);
            shuttleFuelTankActivePlasma.DecreaseFuetlVolume((int)_impulsiveEngine.FuelConsumption(partRoute, shuttleFuelTankGravitonMatter));
            return (true,
                    (_impulsiveEngine.FlightTime(partRoute, shuttleFuelTankActivePlasma), (int)_impulsiveEngine.FuelConsumption(partRoute, shuttleFuelTankGravitonMatter)));
        }

        return (false, (0, 0));
    }

    private (bool CheckFlight, (double Time, int FuelConsumedVolume) Succes) FlightTrough(SpacePartRoute partRoute)
    {
        if (partRoute.EnvironmentOfPart is NebulaeOfIncreasedDensityOfSpace)
           return FlightTroughNebulaeOfIncreasedDensityOfSpace(partRoute);

        if (partRoute.EnvironmentOfPart is Space || partRoute.EnvironmentOfPart is NitrineParticleNebulae)
            return FlightThroughEnvironment(partRoute);

        return (false, (0, 0));
    }
}