using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipArmour;

public interface IArmour
{
    public int HealthPoint => 0;
    public int StartHealthPoint { get; }
    public void GetDamage(IObstacles? obstacles);
    public bool IsAlive();
}