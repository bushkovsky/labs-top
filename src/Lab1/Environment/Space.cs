using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class Space : AbstractEnvironment
{
    public Space(int meteorites, int asteroids)
        : base(new IObstacles[] { new Asteroids(asteroids), new Meteorites(meteorites) }, System.Array.Empty<IPhotonObstacle>()) { }
}
