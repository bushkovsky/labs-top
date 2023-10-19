using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.Deflectors;

public class DeflectorThree : IDeflector
{
    private const int CoefficientMeteoriteDamage = 18;
    private const int CoefficientAsteroidDamage = 15;
    private const int CoefficientSpaceWhaleDamage = 20;

    private int _healthPoint;
    private IModification? _modification;

    public DeflectorThree(IModification? modification)
    {
        _healthPoint = StartHealthPoint;
        _modification = modification;
    }

    public int HealthPoint => _healthPoint;
    public int StartHealthPoint { get; } = 1800;

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
        if (_modification is null) return false;
        return true;
    }
}