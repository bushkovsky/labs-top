using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class Space : AbstractEnvironment
{
    public Space(int meteorites, int asteroids)
        : base(new List<IObstacles>() { new Asteroids(asteroids), new Meteorites(meteorites) }) { }
}
