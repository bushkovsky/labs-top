namespace Itmo.ObjectOrientedProgramming.Lab1.Service;

public class ResultDto
{
    public ResultDto(bool crewDeath, bool shipIsDestroy, bool shipGotLost, double time, double fuelConsumedVolume)
    {
        CrewDeath = crewDeath;
        ShipIsDestroy = shipIsDestroy;
        ShipGotLost = shipGotLost;
        Time = time;
        FuelConsumedVolume = fuelConsumedVolume;
    }

    public bool CrewDeath { get; set; }
    public bool ShipIsDestroy { get; set; }
    public bool ShipGotLost { get; set; }
    public double Time { get; set; }
    public double FuelConsumedVolume { get; set; }
}