using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.SpaceshipHulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips;

public class Meridian : SpaceShip
{
    private const int NoGravitonMatter = 0;
    private const int Weight = 350;
    public Meridian(int activePlasmaVolume, PhotonModification? photonModification)
        : base(
            new FuelTank(activePlasmaVolume),
            new FuelTank(NoGravitonMatter),
            new ImpulsiveEngineE(activePlasmaVolume, Weight),
            null,
            new DeflectorTwo(photonModification),
            new SpaceshipHullTwo(),
            true)
    { }
}