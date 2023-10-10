using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.SpaceshipHulls;

public class SpaceshipHull1 : IArmour
{
    private const int HullIsDestroy = -1;
    private const int AsteroidsDamage = 1;

    private int _healthPoint;

    public SpaceshipHull1()
    {
        _healthPoint = AsteroidsDamage + 1;
    }

    public int HealthPoint => _healthPoint;
    public int StartHealthPoint { get; } = AsteroidsDamage + 1;

    public void GetDamage(IObstacles obstacles)
    {
        if (obstacles.GetType() == typeof(Asteroids))
        {
            _healthPoint -= AsteroidsDamage;
        }
        else
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
        return _healthPoint > 0;
    }
}