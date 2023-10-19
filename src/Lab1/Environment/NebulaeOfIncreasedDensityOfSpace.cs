using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class NebulaeOfIncreasedDensityOfSpace : AbstractEnvironment
{
    public NebulaeOfIncreasedDensityOfSpace(int antimatterFlares)
        : base(new List<IObstacles>() { new AntimatterFlares(antimatterFlares) }) { }
}