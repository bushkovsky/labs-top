namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class Meteorites : IPhysicalObstacle
{
    private const int MeteoritesDamage = 10;

    public Meteorites(int count)
    {
        Count = count;
    }

    public int Count { get; }

    public int Damage { get; } = MeteoritesDamage;
}