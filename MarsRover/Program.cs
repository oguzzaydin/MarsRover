using System;
using MarsRover.Coordinates;
using MarsRover.Directions;
using MarsRover.Grids;
using MarsRover.Locations;
using MarsRover.Rovers;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            string[] data = { "1", "2", "0", "LMLMLMLMMLM", "3", "3", "1", "MMRMMRMRRM" };

            var serviceProvider = CreateContainerBuilder();
            var grid = serviceProvider.GetService<IGrid>();

            grid.SetCoordinates(5,5);


            for (var i = 0; i < 7; i = i + 4)
            {
                var rover = serviceProvider.GetService<IRover>();
                rover.SetLocation(Convert.ToInt32(data[i]), Convert.ToInt32(data[i + 1]));
                rover.TurnDirection((DirectionType)Convert.ToInt32(data[i + 2]));
                rover.MoveAllRoversOnGrid(data[i + 3]);
                Console.WriteLine(rover.GetCurrentPosition());
            }
        }


        private static ServiceProvider CreateContainerBuilder()
        {
            return new ServiceCollection()
                .AddTransient<IGrid, Grid>()
                .AddTransient<ICoordinate, Coordinate>()
                .AddTransient<ILocation, Location>()
                .AddTransient<IDirection, Direction>()
                .AddTransient<IRover, Rover>()
                .BuildServiceProvider();
        }
    }
}
