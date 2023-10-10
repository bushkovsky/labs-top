using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public abstract class AbstractEnvironment
{
    protected AbstractEnvironment(int meteorites, int asteroids, int spaceWhales, int antimatterFlares)
    {
        Meteorites = new Meteorites() { Count = meteorites };
        SpaceWhales = new SpaceWhale() { Count = spaceWhales };
        Asteroids = new Asteroids() { Count = asteroids };
        AntimatterFlares = new AntimatterFlares() { Count = antimatterFlares };
    }

    public Meteorites Meteorites { get; } // init remove pls
    public Asteroids Asteroids { get; init; }
    public SpaceWhale SpaceWhales { get; init; }
    public AntimatterFlares AntimatterFlares { get; init; }
}