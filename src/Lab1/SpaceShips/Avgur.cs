using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.SpaceshipHulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips;

public class Avgur : SpaceShip
{
    private const int Weight = 600;

    public Avgur(int activePlasmaVolume, int gravitonMatterVolume, PhotonModification? photonModification)
        : base(
            new FuelTank(activePlasmaVolume),
            new FuelTank(gravitonMatterVolume),
            new ImpulsiveEngineC(activePlasmaVolume, Weight),
            new Alpha(gravitonMatterVolume, Weight),
            new DeflectorThree(photonModification),
            new SpaceshipHullThree(),
            false)
    { }
}