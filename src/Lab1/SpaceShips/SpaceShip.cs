using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.PartRoute;
using Itmo.ObjectOrientedProgramming.Lab1.ShipArmour;
using Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Dto;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips;

public class SpaceShip
{
    private readonly bool _antinitrineEmitter;
    public SpaceShip(FuelTank shuttleFuelTankActivePlasma, FuelTank shuttleFuelTankGravitonMatter, IImpulsiveEngine impulsiveEngine, JumpEngine? jumpEngine, IDeflector? deflector, IArmour spaceShipHull, bool antinitrineEmitter)
    {
        ShuttleFuelTankActivePlasma = shuttleFuelTankActivePlasma;
        ShuttleFuelTankGravitonMatter = shuttleFuelTankGravitonMatter;
        ImpulsiveEngine = impulsiveEngine;
        JumpEngine = jumpEngine;
        Deflector = deflector;
        SpaceShipHull = spaceShipHull;
        _antinitrineEmitter = antinitrineEmitter;
        StartDistance = jumpEngine?.StartDistance ?? 0;
    }

    public IImpulsiveEngine ImpulsiveEngine { get; private set; }
    public JumpEngine? JumpEngine { get; private set; }
    public IDeflector? Deflector { get; private set; }
    public IArmour SpaceShipHull { get; private set; }
    public FuelTank ShuttleFuelTankActivePlasma { get; private set; }
    public FuelTank ShuttleFuelTankGravitonMatter { get; private set; }
    public int StartDistance { get; }

    // public IArmour? SpaceShipHull => _spaceShipHull;
    public void ArmourGetDamage(IArmour armour, IObstacles obstacle)
    {
        if (!_antinitrineEmitter && obstacle is SpaceWhale) armour.GetDamage(obstacle);
        else if (obstacle is not SpaceWhale) armour.GetDamage(obstacle);

        if (Deflector is not null && !Deflector.IsAlive())
        {
            Deflector = null;
        }
    }

    public void GetDamageAntimatterFlares(IObstacles photonObstacle)
    {
        if (Deflector is null) return;

        Deflector.GetDamage(photonObstacle);

        if (!(Deflector.ModificationIsAlive() || photonObstacle.Count == 0))
        {
            Deflector.DestroyModification();
        }
    }

    public ResultFLightDto FlightTroughNebulaeOfIncreasedDensityOfSpace(SpacePartRoute partRoute)
    {
        if (JumpEngine is not null)
        {
            JumpEngine.Flight(partRoute);
            if (JumpEngine.IsSuccessfulFlight(partRoute))
            {
                ShuttleFuelTankGravitonMatter.DecreaseFuetlVolume(
                        JumpEngine.FuelConsumption(partRoute, ShuttleFuelTankGravitonMatter));

                return new ResultFLightDto(JumpEngine.FuelConsumption(partRoute, ShuttleFuelTankGravitonMatter), true, JumpEngine.FlightTime());
            }
        }

        return new ResultFLightDto(0, false, 0);
    }

    public ResultFLightDto FlightThroughEnvironment(SpacePartRoute partRoute)
    {
        if (ImpulsiveEngine.IsSuccessfulFlight(partRoute, ShuttleFuelTankActivePlasma))
        {
            ImpulsiveEngine.Flight(partRoute, ShuttleFuelTankActivePlasma);
            ShuttleFuelTankActivePlasma.DecreaseFuetlVolume((int)ImpulsiveEngine.FuelConsumption(partRoute, ShuttleFuelTankGravitonMatter));
            return new ResultFLightDto(ImpulsiveEngine.FuelConsumption(partRoute, ShuttleFuelTankGravitonMatter), true, ImpulsiveEngine.FlightTime(partRoute, ShuttleFuelTankActivePlasma));
        }

        return new ResultFLightDto(0, false, 0);
    }
}
