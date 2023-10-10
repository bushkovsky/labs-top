using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.Deflectors;

public interface IDeflector : IArmour
{
    public bool ModificationIsAlive();
    public void DestroyModification();

    public bool ModificationExist();
    public void GetDamage(IPhotonObstacle photonObstacle);
}