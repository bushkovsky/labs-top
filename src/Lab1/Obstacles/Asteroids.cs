namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class Asteroids : IPhysicalObstacle
{
   private const int AsteroidsDamage = 3;

   public Asteroids(int count)
   {
      Count = count;
   }

   public int Count { get; }
   public int Damage { get; } = AsteroidsDamage;
}