using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.PartRoute;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route;

public class SpaceRoute
{
    public SpaceRoute(IList<SpacePartRoute> route)
    {
        Route = route;
    }

    public IList<SpacePartRoute> Route { get; }
}