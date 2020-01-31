using System;
using MarsRover.Coordinates;
using MarsRover.Directions;
using MarsRover.Plateaus;

namespace MarsRover.Locations
{
    public class Location : CoordinateValidator, ILocation
    {
        private readonly IPlateau _plateau;
        public int X { get; set; }
        public int Y { get; set; }

        public Location(IPlateau plateau)
        {
            _plateau = plateau;
        }

        protected override void Validate(ICoordinate coordinate)
        {
            var isValidX = coordinate.X >= 0 && coordinate.X <= _plateau.X;
            var isValidY = coordinate.Y >= 0 && coordinate.Y <= _plateau.Y;
            if (!(isValidX && isValidY))
                throw new Exception("Location is not valid.");
        }

        public void SetLocation(ICoordinate coordinate)
        {
            Validate(coordinate);
            X = coordinate.X;
            Y = coordinate.Y;
        }

        public void ChangeLocation(DirectionType currentDirection)
        {
            switch (currentDirection)
            {
                case DirectionType.North:
                    Y++;
                    break;
                case DirectionType.East:
                    X++;
                    break;
                case DirectionType.West:
                    X--;
                    break;
                case DirectionType.South:
                    Y--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(currentDirection), currentDirection, "CurrentDirection");
            }
        }

       
    }
}
