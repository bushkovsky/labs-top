using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class NitrineParticleNebulae : AbstractEnvironment
{
    public NitrineParticleNebulae(int spaceWhale)
        : base(new IObstacles[] { new SpaceWhale(spaceWhale) }, System.Array.Empty<IPhotonObstacle>()) { }
}