using System;
using MarsRover.Directions;

namespace MarsRover.Locations
{
    public class Location : Coordinates, ILocation
    {
        public void ChangeLocation(DirectionType currentDirection)
        {
            switch (currentDirection)
            {
                case (int)DirectionType.North:
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
