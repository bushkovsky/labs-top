using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public abstract class AbstractEnvironment
{
    protected AbstractEnvironment(IList<IObstacles> environmentObstacles)
    {
        EnvironmentObstacles = environmentObstacles;
    }

    public IList<IObstacles> EnvironmentObstacles { get; }

    public int ObstaclesCount()
    {
        return EnvironmentObstacles.Count;
    }
}