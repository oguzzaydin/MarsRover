namespace MarsRover.Coordinates
{
    public interface ICoordinate
    {
        int X { get; set; }
        int Y { get; set; }
    }


    public interface ICoordinateOperation
    {
        void SetCoordinates(ICoordinate coordinates);
        void IsValid(ICoordinate coordinates);
    }
}
