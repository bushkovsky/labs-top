namespace Itmo.ObjectOrientedProgramming.Lab1.Service;

public record ResultDto
{
    public ResultDto(bool crewDeath, bool shipIsDestroy, bool shipGotLost, double time, double fuelConsumedVolume)
    {
        CrewDeath = crewDeath;
        ShipIsDestroy = shipIsDestroy;
        ShipGotLost = shipGotLost;
        Time = time;
        FuelConsumedVolume = fuelConsumedVolume;
    }

    public bool CrewDeath { get; }
    public bool ShipIsDestroy { get; }
    public bool ShipGotLost { get; }
    public double Time { get; set; }
    public double FuelConsumedVolume { get; }
}