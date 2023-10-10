using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.PartRoute;
using Itmo.ObjectOrientedProgramming.Lab1.ShipArmour;
using Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips;

public class SpaceShip : ISpaceShip
{
    private IImpulsiveEngine? _impulsiveEngine;
    private JumpEngine? _jumpEngine;

    private IDeflector? _deflector;
    private IArmour? _spaceShipHull;

    private bool _antinitrineEmitter;

    protected SpaceShip(FuelTank? shuttleFuelTankActivePlasma, FuelTank? shuttleFuelTankGravitonMatter, IImpulsiveEngine? impulsiveEngine, JumpEngine? jumpEngine, IDeflector? deflector, IArmour? spaceShipHull, bool antinitrineEmitter)
    {
        ShuttleFuelTankActivePlasma = shuttleFuelTankActivePlasma;
        ShuttleFuelTankGravitonMatter = shuttleFuelTankGravitonMatter;
        _impulsiveEngine = impulsiveEngine;
        _jumpEngine = jumpEngine;
        _deflector = deflector;
        _spaceShipHull = spaceShipHull;
        _antinitrineEmitter = antinitrineEmitter;
        StartDistance = jumpEngine?.StartDistance ?? 0;
    }

    public int StartDistance { get; }

    public IArmour? SpaceShipHull => _spaceShipHull;
    private FuelTank? ShuttleFuelTankActivePlasma { get; set; }
    private FuelTank? ShuttleFuelTankGravitonMatter { get; set; }

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
        if (_impulsiveEngine is not null) return _impulsiveEngine.FuelConsumption(partRoute, ShuttleFuelTankActivePlasma);
        return -1;
    }

    private bool ShipIsAlive()
    {
        return _spaceShipHull is not null && _spaceShipHull.IsAlive();
    }

    private void ArmourGetDamage(IArmour armour, SpacePartRoute partRoute)
    {
        while (armour.IsAlive() && !_antinitrineEmitter && partRoute.EnvironmentOfPart.SpaceWhales.Count > 0)
        {
           armour.GetDamage(partRoute.EnvironmentOfPart.SpaceWhales);
        }

        while (armour.IsAlive() && partRoute.EnvironmentOfPart.Meteorites.Count > 0)
        {
            armour.GetDamage(partRoute.EnvironmentOfPart.Meteorites);
        }

        while (armour.IsAlive() && partRoute.EnvironmentOfPart.Asteroids.Count > 0)
        {
            armour.GetDamage(partRoute.EnvironmentOfPart.Asteroids);
        }
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

            if (!_spaceShipHull.IsAlive())
            {
                _spaceShipHull = null;
            }
        }

        return ShipIsAlive();
    }

    private bool AntimatterFlaresDamage(SpacePartRoute partRoute)
    {
        if (_deflector is not null)
        {
            _deflector.GetDamage(partRoute.EnvironmentOfPart.AntimatterFlares);

            if (!(_deflector.ModificationIsAlive() || partRoute.EnvironmentOfPart.AntimatterFlares.Count == 0))
            {
                _deflector.DestroyModification();
            }

            return _deflector.ModificationIsAlive() || partRoute.EnvironmentOfPart.AntimatterFlares.Count == 0;
        }

        return partRoute.EnvironmentOfPart.AntimatterFlares.Count == 0;
    }

    private (bool CheckFlight, (double Time, int FuelConsumedVolume) Succes) FlightTroughNebulaeOfIncreasedDensityOfSpace(SpacePartRoute partRoute)
    {
        if (_jumpEngine is not null)
        {
            _jumpEngine.Flight(partRoute);
            if (_jumpEngine.IsSuccessfulFlight(partRoute))
            {
                if (ShuttleFuelTankGravitonMatter is not null)
                {
                    ShuttleFuelTankGravitonMatter.FuelVolume -=
                        _jumpEngine.FuelConsumption(partRoute, ShuttleFuelTankGravitonMatter);
                }

                return (true,
                    (_jumpEngine.FlightTime(), _jumpEngine.FuelConsumption(partRoute, ShuttleFuelTankGravitonMatter)));
            }
        }

        return (false, (0, 0));
    }

    private (bool CheckFlight, (int Time, int FuelConsumedVolume) Succes) FlightThroughEnvironment(SpacePartRoute partRoute)
    {
        if (_impulsiveEngine is not null)
        {
            if (ShuttleFuelTankActivePlasma is not null &&
                _impulsiveEngine.IsSuccessfulStart(ShuttleFuelTankActivePlasma))
            {
                ShuttleFuelTankActivePlasma.FuelVolume = _impulsiveEngine.Start(ShuttleFuelTankActivePlasma);
            }
            else
            {
                return (false, (0, 0));
            }

            _impulsiveEngine.Flight(partRoute);
            if (_impulsiveEngine.IsSuccessfulFlight(partRoute))
            {
                ShuttleFuelTankActivePlasma.FuelVolume -=
                    (int)_impulsiveEngine.FuelConsumption(partRoute, ShuttleFuelTankGravitonMatter);
                return (true,
                    (_impulsiveEngine.FlightTime(partRoute, ShuttleFuelTankActivePlasma), (int)_impulsiveEngine.FuelConsumption(partRoute, ShuttleFuelTankGravitonMatter)));
            }
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