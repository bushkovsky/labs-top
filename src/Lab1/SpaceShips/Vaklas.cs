using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.SpaceshipHulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips;

public class Vaklas : SpaceShip
{
    private const int Weight = 350;

    public Vaklas(int activePlasmaVolume, int gravitonMatterVolume, PhotonModification? photonModification)
        : base(
            new FuelTank(activePlasmaVolume),
            new FuelTank(gravitonMatterVolume),
            new ImpulsiveEngineE(activePlasmaVolume, Weight),
            new Gamma(gravitonMatterVolume, Weight),
            new DeflectorOne(photonModification),
            new SpaceshipHullTwo(),
            false)
    { }
}