namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Asteroid : IObstacle 
{
    public Asteroid(int pointsOfDamage)
    {
        Damage = pointsOfDamage;
    }

    public int Damage { get;  init; }
}