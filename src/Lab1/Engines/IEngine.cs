namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public interface IEngine
{
    public void Flight(PartRoute.SpacePartRoute partRoute);
    public bool IsSuccessfulFlight(PartRoute.SpacePartRoute partRoute);
}