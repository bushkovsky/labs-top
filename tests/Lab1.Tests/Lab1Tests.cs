using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.PartRoute;
using Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Lab1Tests
{
    public static System.Collections.Generic.IEnumerable<object[]> ShouldFlightCase()
    {
        yield return new object[] { new[] { new SpacePartRoute(100, new NebulaeOfIncreasedDensityOfSpace(1)) }, new PleasureShuttle(100), new Avgur(100, 100, null) };
    }

    [Theory]
    [MemberData(nameof(ShouldFlightCase))]
    public void ShouldFlight(SpacePartRoute[] route, PleasureShuttle pleasureShuttle, Avgur avgur)
    {
        Assert.False(pleasureShuttle.Flight(route).Item3.Item1);
        Assert.False(avgur.Flight(route).Item3.Item1);
    }

    [Theory]
    [InlineData(100, 1, 100, 100)]
    public void ShouldFlight2Vaklas(int distance, int countAntimatterFlares, int activePlasmaVolume, int gravitoMatterVolume)
    {
        SpacePartRoute[] route = { new SpacePartRoute(distance, new NebulaeOfIncreasedDensityOfSpace(countAntimatterFlares)) };
        var vaklasWithoutPhatonDeflector = new Vaklas(activePlasmaVolume, gravitoMatterVolume, null);

        var vaklasWithPhatonDeflector = new Vaklas(activePlasmaVolume, gravitoMatterVolume, new PhotonModification());
        Assert.False(vaklasWithoutPhatonDeflector.Flight(route).Item1);

        Assert.True(vaklasWithPhatonDeflector.Flight(route).Item1);
    }

    [Theory]
    [InlineData(100, 100, 100, 1)]
    public void ShouldFlightVaklasAvgurMeridian(int distance, int activePlasmaVolume, int gravitoMatterVolume, int spaceWhaleCount)
    {
        SpacePartRoute[] route = { new SpacePartRoute(distance, new NitrineParticleNebulae(spaceWhaleCount)) };

        var vaklas = new Vaklas(activePlasmaVolume, gravitoMatterVolume, null);
        var avgur = new Avgur(activePlasmaVolume, gravitoMatterVolume, null);
        var meridian = new Meridian(activePlasmaVolume, null);
        Assert.False(vaklas.Flight(route).Item2);
        Assert.True(avgur.SpaceShipHull != null && avgur.Flight(route).Item2 &&
                   avgur.SpaceShipHull.HealthPoint <= avgur.SpaceShipHull.StartHealthPoint);

        Assert.True(meridian.SpaceShipHull != null && meridian.Flight(route).Item2 &&
                    meridian.SpaceShipHull.HealthPoint == meridian.SpaceShipHull.StartHealthPoint);
    }

    [Theory]
    [InlineData(5, 100, 100, 0, 0)]
    public void ShouldFlightPlesureVaklas(int distance, int activePlasmaVolume, int gravitoMatterVolume, int meteorites, int asteroids)
    {
        SpacePartRoute[] route = { new SpacePartRoute(distance, new Space(meteorites, asteroids)) };

        var vaklas = new Vaklas(activePlasmaVolume, gravitoMatterVolume, null);
        var pleasureShuttle = new PleasureShuttle(activePlasmaVolume);

        Assert.True(vaklas.ShipFuelConsumption(route[0]) > pleasureShuttle.ShipFuelConsumption(route[0]));
    }

    [Theory]
    [InlineData(50, 100, 1600, 0)]
    public void ShouldFlightAvgurStella(int distance, int activePlasmaVolume, int gravityMatterVolume, int antimatterFlares)
    {
        SpacePartRoute[] route = { new(distance, new NebulaeOfIncreasedDensityOfSpace(antimatterFlares)) };
        var stella = new Stella(activePlasmaVolume, gravityMatterVolume, null);
        var avgur = new Avgur(activePlasmaVolume, gravityMatterVolume, null);
        Assert.True(avgur.Flight(route).Item3.Item1);
        Assert.True(stella.Flight(route).Item3.Item1);
        Assert.True(avgur.StartDistance < stella.StartDistance);
    }

    [Theory]
    [InlineData(5, 45000, 1600, 0)]
    public void ShouldFlightVaklasPleasureShuttle(int distance, int activePlasmaVolume, int gravityMatterVolume, int spaceWhale)
    {
        SpacePartRoute[] route = { new(distance, new NitrineParticleNebulae(spaceWhale)) };
        var vaklas = new Vaklas(activePlasmaVolume, gravityMatterVolume, null);
        var pleasureShuttle = new PleasureShuttle(activePlasmaVolume);

        Assert.True(vaklas.Flight(route).Item1 && vaklas.Flight(route).Item2 && vaklas.Flight(route).Item3.Item1);
        Assert.False(pleasureShuttle.Flight(route).Item3.Item1);
    }

    [Theory]
    [InlineData(5, 20, 45000)]
    public void ShouldFlightPleasureShuttle(int distanceFirstSection, int distanceSecondtSection, int activePlasmaVolume)
    {
        SpacePartRoute[] route = { new(distanceFirstSection, new Space(0, 0)), new(distanceSecondtSection, new Space(0, 1)) };
        var pleasureShuttle = new PleasureShuttle(activePlasmaVolume);
        Assert.False(pleasureShuttle.Flight(route).Item3.Item1 && pleasureShuttle.Flight(route).Item1 && pleasureShuttle.Flight(route).Item2);
    }
}
