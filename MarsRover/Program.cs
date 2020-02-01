using MarsRover.Coordinates;
using MarsRover.Directions;
using MarsRover.Locations;
using MarsRover.Plateaus;
using MarsRover.Rovers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover
{
    internal static class Program
    {
        private static void Main()
        {
            string[] input = { "1", "2", "0", "LMLMLMLMM", "3", "3", "1", "MMRMMRMRRM" };

            var serviceProvider = CreateContainerBuilder();
            var plateau = serviceProvider.GetService<IPlateau>();
            plateau.SetSize(new Coordinate(5, 5));

            for (var i = 0; i < 7; i = i + 4)
            {
                var rover = serviceProvider.GetService<IRover>();
                rover.SetLocation(new Coordinate(Convert.ToInt32(input[i]), Convert.ToInt32(input[i + 1])));
                rover.TurnDirection((DirectionType)Convert.ToInt32(input[i + 2]));
                rover.GiveCommand(input[i + 3]);
                Console.WriteLine(rover.GetCurrentPosition());
            }
        }

        private static ServiceProvider CreateContainerBuilder()
        {
            return new ServiceCollection()
                .AddScoped<IPlateau, Plateau>()
                .AddScoped<ILocation, Location>()
                .AddScoped<IDirection, Direction>()
                .AddScoped<IRover, Rover>()
                .BuildServiceProvider();
        }
    }
}
