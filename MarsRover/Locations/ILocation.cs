using MarsRover.Coordinates;
using MarsRover.Directions;

namespace MarsRover.Locations
{
    public interface ILocation : ICoordinate
    {
        void SetLocation(ICoordinate coordinate);
        void ChangeLocation(DirectionType currentDirection);
    }
}
