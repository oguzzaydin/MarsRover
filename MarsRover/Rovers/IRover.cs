using MarsRover.Coordinates;
using MarsRover.Directions;

namespace MarsRover.Rovers
{
    public interface IRover
    {
        void SetLocation(ICoordinate coordinate);
        void TurnDirection(DirectionType direction);
        string GetCurrentPosition();
        void GiveCommand(string instruction);
    }
}
