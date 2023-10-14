namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class Meteorites : IObstacles
{
    public Meteorites(int count)
    {
        Count = count;
    }

    public int Count { get; }
}