using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class NitrineParticleNebulae : AbstractEnvironment
{
    public NitrineParticleNebulae(int spaceWhale)
        : base(new List<IObstacles>() { new SpaceWhale(spaceWhale) }) { }
}