using MarsRover.Coordinates;

namespace MarsRover.Plateaus
{
    public interface IPlateau : ICoordinate
    {
        void SetSize(ICoordinate coordinate);
    }
}
