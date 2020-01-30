namespace MarsRover.Coordinates
{
    public interface ICoordinateOperation
    {
        void SetCoordinates(int x, int y);
        void IsValid(ICoordinate coordinates);
    }
}
