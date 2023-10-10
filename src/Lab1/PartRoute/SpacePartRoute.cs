using Itmo.ObjectOrientedProgramming.Lab1.Environment;

namespace Itmo.ObjectOrientedProgramming.Lab1.PartRoute;

public class SpacePartRoute
{
    public SpacePartRoute(int distance, AbstractEnvironment environment)
    {
        Distance = distance;
        EnvironmentOfPart = environment;
    }

    public int Distance { get; init; }
    public AbstractEnvironment EnvironmentOfPart { get; init; }
}