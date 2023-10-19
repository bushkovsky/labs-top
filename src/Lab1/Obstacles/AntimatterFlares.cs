namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class AntimatterFlares : IPhotonObstacle
{
    private const int AntimatterFlaresDamage = 1;

    public AntimatterFlares(int count)
    {
        Count = count;
    }

    public int Count { get; }
    public int Damage { get; } = AntimatterFlaresDamage;
}