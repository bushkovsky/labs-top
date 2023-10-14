namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class Asteroids : IObstacles
{
   public Asteroids(int count)
   {
      Count = count;
   }

   public int Count { get; }
}