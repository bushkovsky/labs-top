using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public abstract class AbstractEnvironment
{
    private IObstacles[] environmentObstacles;
    private IPhotonObstacle[] environmentPhotonObstacles;
    protected AbstractEnvironment(IObstacles[] environmentObstacles, IPhotonObstacle[] environmentPhotonObstacles)
    {
        this.environmentObstacles = environmentObstacles;
        this.environmentPhotonObstacles = environmentPhotonObstacles;
    }

    public IObstacles? GetObstacleByIndex(int index)
    {
        return index < environmentObstacles.Length ? environmentObstacles[index] : null;
    }

    public IPhotonObstacle? GetPhotonObstacleByIndex(int index)
    {
        return index < environmentPhotonObstacles.Length ? environmentPhotonObstacles[index] : null;
    }

    public int ObstaclesCount()
    {
        return environmentObstacles.Length;
    }

    public int PhotonObstaclesCount()
    {
        return environmentPhotonObstacles.Length;
    }
}