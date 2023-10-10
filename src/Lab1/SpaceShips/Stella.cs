using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.SpaceshipHulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips;

public class Stella : SpaceShip
{
    private const int Weight = 100;

    public Stella(int activePlasmaVolume, int gravitonMatterVolume, PhotonModification? photonModification)
        : base(new FuelTank() { FuelVolume = activePlasmaVolume, Type = FuelType.ActivePlasma }, new FuelTank() { FuelVolume = gravitonMatterVolume, Type = FuelType.GravitonMatter }, new ImpulsiveEngineC(activePlasmaVolume, Weight), new Omega(gravitonMatterVolume, Weight), new Deflector1(photonModification), new SpaceshipHull1(), false)
    { }
}