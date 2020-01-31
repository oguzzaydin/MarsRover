using MarsRover.Coordinates;
using System;

namespace MarsRover.Plateaus
{
    public class Plateau : CoordinateValidator, IPlateau
    {
        public int X { get; set; }
        public int Y { get; set; }

        protected override void Validate(ICoordinate coordinate)
        {
            if (coordinate.X < 0 && coordinate.Y < 0)
                throw new Exception("Invalid plateau location");
        }

        public void SetSize(ICoordinate coordinate)
        {
            Validate(coordinate);
            X = coordinate.X;
            Y = coordinate.Y;
        }
    }
}
