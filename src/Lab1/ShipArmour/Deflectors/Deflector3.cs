using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.Deflectors;

public class Deflector3 : IDeflector
{
    private const int MeteoriteDamage = 40;
    private const int AsteroidDamage = 10;
    private const int SpaceWhaleDamage = 400;

    private int _healthPoint;
    private IModification? _modification;

    public Deflector3(IModification? modification)
    {
        _healthPoint = SpaceWhaleDamage + 1;
        _modification = modification;
    }

    public int HealthPoint => _healthPoint;
    public int StartHealthPoint { get; } = SpaceWhaleDamage + 1;

    public void GetDamage(IObstacles? obstacles)
    {
        if (obstacles is null) return;
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles is Asteroids)
            {
                _healthPoint -= AsteroidDamage;
                return;
            }

            if (obstacles is Meteorites)
            {
                _healthPoint -= MeteoriteDamage;
                return;
            }

            if (obstacles is SpaceWhale)
            {
                _healthPoint -= SpaceWhaleDamage;
            }
        }
    }

    public void GetDamage(IPhotonObstacle? photonObstacle)
    {
        _modification?.GetDamage(photonObstacle);
    }

    public bool IsAlive()
    {
        if (_healthPoint <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
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