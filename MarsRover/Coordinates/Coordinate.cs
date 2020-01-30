using System;

namespace MarsRover.Coordinates
{
    public abstract class Coordinate : ICoordinate, ICoordinateOperation
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void SetCoordinates(int x, int y)
        {
            Validate(this);
            X = x;
            Y = y;
        }

        public void Validate(ICoordinate coordinates)
        {
            var isValidX = coordinates.X >= 0 && coordinates.X <= X;
            var isValidY = coordinates.Y >= 0 && coordinates.Y <= Y;

            if(!(isValidX && isValidY))
                throw new Exception("Location is not valid.");
        }
    }
}
