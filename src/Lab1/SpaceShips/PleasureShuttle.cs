using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.SpaceshipHulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips;

public class PleasureShuttle : SpaceShip
{
    private const int NoGravitonMatter = 0;
    private const int Weight = 100;
    public PleasureShuttle(int activePlasmaVolume)
        : base(
            new FuelTank(activePlasmaVolume),
            new FuelTank(NoGravitonMatter),
            new ImpulsiveEngineC(activePlasmaVolume, Weight),
            null,
            null,
            new SpaceshipHullOne(),
            false)
    { }
}