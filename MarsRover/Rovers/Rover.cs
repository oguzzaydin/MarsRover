using MarsRover.Directions;
using MarsRover.Locations;
using System;

namespace MarsRover.Rovers
{
    public class Rover : IRover
    {
        private readonly ILocation _location;
        private readonly IDirection _direction;

        public Rover(ILocation location, IDirection direction)
        {
            _location = location;
            _direction = direction;
        }

        public void SetLocation(int x, int y)
        {
            _location.SetCoordinates(x,y);
        }

        public void TurnDirection(DirectionType direction)
        {
            _direction.CurrentDirection = direction;
        }

        public string GetCurrentPosition() => $"{_location.X} {_location.Y} {Enum.GetName(typeof(DirectionType), _direction.CurrentDirection)}";

        public void MoveAllRoversOnGrid(string instruction)
        {
            foreach (var direction in instruction)
            {
                switch (direction)
                {
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'M':
                        ProcessMoveInstruction();
                        break;
                    default:
                        throw new Exception("Invalid Instruction Processed. Please supply only L,R and M");
                }
            }
        }

        private void TurnLeft()
        {
            if (_direction.CurrentDirection == DirectionType.North)
                _direction.CurrentDirection = (DirectionType)4;
            _direction.CurrentDirection -= 1;
        }

        private void TurnRight()
        {
            if (_direction.CurrentDirection == DirectionType.West)
                _direction.CurrentDirection = default;
            _direction.CurrentDirection += 1;
        }

        private void ProcessMoveInstruction()
        {
            _location.ChangeLocation(_direction.CurrentDirection);
        }
    }
}
