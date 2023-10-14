using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class NebulaeOfIncreasedDensityOfSpace : AbstractEnvironment
{
    public NebulaeOfIncreasedDensityOfSpace(int antimatterFlares)
        : base(System.Array.Empty<IObstacles>(), new IPhotonObstacle[] { new AntimatterFlares(antimatterFlares) }) { }
}