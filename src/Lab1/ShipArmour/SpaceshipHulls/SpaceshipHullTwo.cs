using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.SpaceshipHulls;

public class SpaceshipHullTwo : IArmour
{
    private const int CoefficientMeteoriteDamage = 3;
    private const int CoefficientAsteroidDamage = 4;
    private const int CoefficientSpaceWhaleDamage = 1;
    private int _healthPoint;

    public SpaceshipHullTwo()
    {
        _healthPoint = StartHealthPoint;
    }

    public int HealthPoint => _healthPoint;
    public int StartHealthPoint { get; } = 60;

    public void GetDamage(IObstacles obstacle)
    {
        if (obstacle is Asteroids)
        {
            _healthPoint -= obstacle.Count * CoefficientAsteroidDamage * obstacle.Damage;
            return;
        }

        if (obstacle is Meteorites)
        {
            _healthPoint -= obstacle.Count * CoefficientMeteoriteDamage * obstacle.Damage;
            return;
        }

        if (obstacle is SpaceWhale)
        {
            _healthPoint -= obstacle.Count * CoefficientSpaceWhaleDamage * obstacle.Damage;
        }
    }

    public bool IsAlive()
    {
        return !(_healthPoint <= 0);
    }
}