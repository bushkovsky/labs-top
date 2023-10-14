using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.SpaceshipHulls;

public class SpaceshipHull2 : IArmour
{
    private const int HullIsDestroy = -1;
    private const int AsteroidsDamage = 2;
    private const int MeteoritesDamage = 5;

    private int _healthPoint;

    public SpaceshipHull2()
    {
        _healthPoint = (AsteroidsDamage * MeteoritesDamage) + 1;
    }

    public int HealthPoint => _healthPoint;
    public int StartHealthPoint { get; } = (AsteroidsDamage * MeteoritesDamage) + 1;

    public void GetDamage(IObstacles? obstacles)
    {
        if (obstacles is null) return;

        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles is Asteroids)
            {
                _healthPoint -= AsteroidsDamage;
                return;
            }

            if (obstacles is Meteorites)
            {
                _healthPoint -= MeteoritesDamage;
                return;
            }

            if (obstacles is SpaceWhale)
            {
                _healthPoint = HullIsDestroy;
            }
        }
    }

    public bool IsAlive()
    {
        return !(_healthPoint <= 0);
    }
}