using MarsRover.Coordinates;
using MarsRover.Directions;

namespace MarsRover.Rovers
{
    public interface IRover
    {
        void SetLocation(int x, int y);
        void TurnDirection(DirectionType direction);
        string GetCurrentPosition();
        void MoveAllRoversOnGrid(string instruction);
    }
}
