using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.PartRoute;
using Itmo.ObjectOrientedProgramming.Lab1.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Service;
using Itmo.ObjectOrientedProgramming.Lab1.ShipArmour.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class LabOneShuttlesAndRoutes
{
    public static IEnumerable<object[]> ShouldFlightCase()
    {
        yield return new object[]
        {
            new ProcessingService(
            new PleasureShuttle(100),
            new SpaceRoute(new List<SpacePartRoute>() { new SpacePartRoute(100, new NebulaeOfIncreasedDensityOfSpace(1)) })),
            new ProcessingService(
            new Avgur(100, 100, null),
            new SpaceRoute(new List<SpacePartRoute>() { new SpacePartRoute(100, new NebulaeOfIncreasedDensityOfSpace(1)) })),
        };
    }

    [Theory]
    [MemberData(nameof(ShouldFlightCase))]
    public void ShouldFlight(ProcessingService pleasureShuttleProcessingService, ProcessingService avgurProcessingService)
    {
        Assert.False(pleasureShuttleProcessingService.Flight().ShipGotLost);
        Assert.False(avgurProcessingService.Flight().ShipGotLost);
    }

    [Theory]
    [InlineData(100, 1, 100, 100)]
    public void ShouldFlight2Vaklas(int distance, int countAntimatterFlares, int activePlasmaVolume, int gravitoMatterVolume)
    {
        var route = new SpaceRoute(new List<SpacePartRoute>() { new SpacePartRoute(distance, new NebulaeOfIncreasedDensityOfSpace(countAntimatterFlares)) });

        var vaklasWithoutPhatonDeflector = new Vaklas(activePlasmaVolume, gravitoMatterVolume, null);
        var vaklasWithPhatonDeflector = new Vaklas(activePlasmaVolume, gravitoMatterVolume, new PhotonModification());

        var vaklasWithoutService = new ProcessingService(vaklasWithoutPhatonDeflector, route);
        var vaklasWithService = new ProcessingService(vaklasWithPhatonDeflector, route);

        Assert.False(vaklasWithoutService.Flight().CrewDeath);
        Assert.True(vaklasWithService.Flight().CrewDeath);
    }

    [Theory]
    [InlineData(100, 100, 100, 1)]
    public void ShouldFlightVaklasAvgurMeridian(int distance, int activePlasmaVolume, int gravitoMatterVolume, int spaceWhaleCount)
    {
        var route = new SpaceRoute(new List<SpacePartRoute>() { new SpacePartRoute(distance, new NitrineParticleNebulae(spaceWhaleCount)) });
        var vaklas = new Vaklas(activePlasmaVolume, gravitoMatterVolume, null);
        var avgur = new Avgur(activePlasmaVolume, gravitoMatterVolume, null);
        var meridian = new Meridian(activePlasmaVolume, null);

        var vaklasService = new ProcessingService(vaklas, route);
        var avgursService = new ProcessingService(avgur, route);
        var meridianService = new ProcessingService(meridian, route);
        Assert.False(vaklasService.Flight().ShipIsDestroy);
        Assert.True(avgursService.Flight().ShipIsDestroy &&
                    avgur.SpaceShipHull.HealthPoint <= avgur.SpaceShipHull.StartHealthPoint);

        Assert.True(meridianService.Flight().ShipIsDestroy &&
                    meridian.SpaceShipHull.HealthPoint == meridian.SpaceShipHull.StartHealthPoint);
    }

    [Theory]
    [InlineData(5, 100, 100, 0, 0)]
    public void ShouldFlightPlesureVaklas(int distance, int activePlasmaVolume, int gravitoMatterVolume, int meteorites, int asteroids)
    {
        var vaklas = new Vaklas(activePlasmaVolume, gravitoMatterVolume, null);
        var pleasureShuttle = new PleasureShuttle(activePlasmaVolume);

        var route = new SpaceRoute(new List<SpacePartRoute>() { new SpacePartRoute(distance, new Space(meteorites, asteroids)) });

        var vaklasService = new ProcessingService(vaklas, route);
        var pleasureService = new ProcessingService(pleasureShuttle, route);

        Assert.True(vaklasService.ShipFuelConsumption(route.Route[0]) > pleasureService.ShipFuelConsumption(route.Route[0]));
    }

    [Theory]
    [InlineData(50, 100, 1600, 0)]
    public void ShouldFlightAvgurStella(int distance, int activePlasmaVolume, int gravityMatterVolume, int antimatterFlares)
    {
        var route = new SpaceRoute(new List<SpacePartRoute>() { new SpacePartRoute(distance, new NebulaeOfIncreasedDensityOfSpace(antimatterFlares)) });
        var stella = new Stella(activePlasmaVolume, gravityMatterVolume, null);
        var avgur = new Avgur(activePlasmaVolume, gravityMatterVolume, null);

        var avgurService = new ProcessingService(avgur, route);
        var stellaService = new ProcessingService(stella, route);

        Assert.True(avgurService.Flight().ShipGotLost);
        Assert.True(stellaService.Flight().ShipGotLost);
        Assert.True(avgur.StartDistance < stella.StartDistance);
    }

    [Theory]
    [InlineData(5, 45000, 1600, 0)]
    public void ShouldFlightVaklasPleasureShuttle(int distance, int activePlasmaVolume, int gravityMatterVolume, int spaceWhale)
    {
        var route = new SpaceRoute(new List<SpacePartRoute>() { new SpacePartRoute(distance, new NitrineParticleNebulae(spaceWhale)) });
        var vaklas = new Vaklas(activePlasmaVolume, gravityMatterVolume, null);
        var pleasureShuttle = new PleasureShuttle(activePlasmaVolume);

        var vaklasService = new ProcessingService(vaklas, route);
        var pleasureService = new ProcessingService(pleasureShuttle, route);

        Assert.True(vaklasService.Flight().CrewDeath && vaklasService.Flight().ShipIsDestroy && vaklasService.Flight().ShipGotLost);
        Assert.False(pleasureService.Flight().ShipGotLost);
    }

    [Theory]
    [InlineData(5, 20, 45000)]
    public void ShouldFlightPleasureShuttle(int distanceFirstSection, int distanceSecondSection, int activePlasmaVolume)
    {
        var route = new SpaceRoute(new List<SpacePartRoute>() { new SpacePartRoute(distanceFirstSection, new Space(0, 0)), new SpacePartRoute(distanceSecondSection, new Space(0, 1)) });
        var pleasureShuttle = new PleasureShuttle(activePlasmaVolume);

        var pleasureService = new ProcessingService(pleasureShuttle, route);
        Assert.False(pleasureService.Flight().ShipGotLost && pleasureService.Flight().ShipIsDestroy && pleasureService.Flight().CrewDeath);
    }
}