using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.Deflectors;

public interface IModification
{
    public void GetDamage(IObstacles obstacle);
    public bool IsAlive();
}