using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.Deflectors;

public interface IDeflector : IArmour
{
    public bool ModificationIsAlive();
    public void DestroyModification();
    public void GetDamageAntimitter(IObstacles obstacle);
    public bool ModificationExist();
}