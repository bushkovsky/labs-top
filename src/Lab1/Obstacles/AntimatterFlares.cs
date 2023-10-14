namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class AntimatterFlares : IPhotonObstacle
{
    public AntimatterFlares(int count)
    {
        Count = count;
    }

    public int Count { get; }
}