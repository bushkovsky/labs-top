namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class SpaceWhale : IObstacles
{
    public SpaceWhale(int count)
    {
        Count = count;
    }

    public int Count { get; }
}