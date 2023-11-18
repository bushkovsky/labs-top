namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Dto;

public record ResultFLightDto
{
    public ResultFLightDto(double fuelConsumption, bool b, double flightTime)
    {
        Result = b;
        Time = flightTime;
        FuelConsuption = fuelConsumption;
    }

    public bool Result { get; }
    public double Time { get; }
    public double FuelConsuption { get; }
}