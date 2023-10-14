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

    public void GetDamage(IObstacles? obstacles)
    {
        if (obstacles is null) return;
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles is Asteroids)
            {
                _healthPoint -= AsteroidsDamage;
            }
            else
            {
                _healthPoint = HullIsDestroy;
            }
        }
    }

    public bool IsAlive()
    {
        return _healthPoint > 0;
    }
}