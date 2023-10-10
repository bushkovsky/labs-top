using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.SpaceshipHulls;

public class SpaceshipHull3 : IArmour
{
    private const int HullIsDestroy = -1;
    private const int AsteroidsDamage = 5;
    private const int MeteoritesDamage = 20;

    private int _healthPoint;

    public SpaceshipHull3()
    {
        _healthPoint = (AsteroidsDamage * MeteoritesDamage) + 1;
    }

    public int HealthPoint => _healthPoint;
    public int StartHealthPoint { get; } = (AsteroidsDamage * MeteoritesDamage) + 1;

    public void GetDamage(IObstacles obstacles)
    {
        if (obstacles.GetType() == typeof(Asteroids))
        {
            _healthPoint -= AsteroidsDamage;
            return;
        }

        if (obstacles.GetType() == typeof(Meteorites))
        {
            _healthPoint -= MeteoritesDamage;
            return;
        }

        if (obstacles.GetType() == typeof(SpaceWhale))
        {
            _healthPoint = HullIsDestroy;
        }

        if (_healthPoint > 0)
        {
            obstacles.Count -= 1;
        }
    }

    public bool IsAlive()
    {
        return !(_healthPoint <= 0);
    }
}