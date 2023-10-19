using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.SpaceshipHulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips;

public class Stella : SpaceShip
{
    private const int Weight = 100;

    public Stella(int activePlasmaVolume, int gravitonMatterVolume, PhotonModification? photonModification)
        : base(
            new FuelTank(activePlasmaVolume),
            new FuelTank(gravitonMatterVolume),
            new ImpulsiveEngineC(activePlasmaVolume, Weight),
            new Omega(gravitonMatterVolume, Weight),
            new DeflectorOne(photonModification),
            new SpaceshipHullOne(),
            false)
    { }
}