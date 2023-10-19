using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.SpaceshipHulls;

public class SpaceshipHullThree : IArmour
{
    private const int CoefficientMeteoriteDamage = 6;
    private const int CoefficientAsteroidDamage = 5;
    private const int CoefficientSpaceWhaleDamage = 4;
    private int _healthPoint;

    public SpaceshipHullThree()
    {
        _healthPoint = StartHealthPoint;
    }

    public int HealthPoint => _healthPoint;
    public int StartHealthPoint { get; } = 300;

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