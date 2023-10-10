using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.Deflectors;

public class PhotonModification : IModification
{
     private const int AntimatterFlaresDamage = 1;
     private int _healthPoint = 3;

     public void GetDamage(IPhotonObstacle obstacle)
     {
          if (obstacle.GetType() == typeof(AntimatterFlares))
          {
               _healthPoint -= AntimatterFlaresDamage;
          }
     }

     public bool IsAlive()
     {
          return _healthPoint > 0;
     }

     public bool IsCrewDeath()
     {
          return _healthPoint < 0;
     }
}