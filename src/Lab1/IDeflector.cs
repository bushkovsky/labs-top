namespace Itmo.ObjectOrientedProgramming.Lab1;

public interface IDeflector
{
    protected int HealthPoint { get; set; }
    protected void GetDamage(IObstacle obstacle);
    protected bool IsAlive();
}


