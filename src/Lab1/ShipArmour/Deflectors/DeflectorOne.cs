using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.Deflectors;

public class DeflectorOne : IDeflector
{
    private const int CoefficientMeteoriteDamage = 3;
    private const int CoefficientAsteroidDamage = 5;
    private const int CoefficientSpaceWhaleDamage = 1;

    private int _healthPoint;
    private IModification? _modification;

    public DeflectorOne(IModification? modification)
    {
        _healthPoint = StartHealthPoint;
        _modification = modification;
    }

    public double HealthPoint => _healthPoint;
    public int StartHealthPoint { get; } = 30;

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

    public void GetDamageAntimitter(IObstacles obstacle)
    {
        _modification?.GetDamage(obstacle);
    }

    public bool IsAlive()
    {
        return _healthPoint >= 0;
    }

    public bool ModificationIsAlive()
    {
        return _modification is not null && _modification.IsAlive();
    }

    public void DestroyModification()
    {
        _modification = null;
    }

    public bool ModificationExist()
    {
        return _modification is not null;
    }
}