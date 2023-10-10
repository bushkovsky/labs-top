using Itmo.ObjectOrientedProgramming.Lab1.PartRoute;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route;

public class SpaceRoute
{
    private readonly SpacePartRoute[] _route;
    public SpaceRoute(SpacePartRoute[] routes)
    {
        _route = routes;
    }
}