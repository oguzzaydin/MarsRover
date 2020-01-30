using MarsRover.Coordinates;
using MarsRover.Directions;

namespace MarsRover.Locations
{
    public interface ILocation : ICoordinate, ICoordinateOperation
    {
        void ChangeLocation(DirectionType currentDirection);
    }
}
