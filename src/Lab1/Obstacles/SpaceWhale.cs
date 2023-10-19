namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class SpaceWhale : IPhysicalObstacle
{
    private const int SpaceWhaleDamage = 90;

    public SpaceWhale(int count)
    {
        Count = count;
    }

    public int Count { get; }

    public int Damage { get; } = SpaceWhaleDamage;
}