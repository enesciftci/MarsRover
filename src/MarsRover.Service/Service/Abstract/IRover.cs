using MarsRover.Service.Service.Concrete;

namespace MarsRover.Service.Service.Abstract
{
    public interface IRover
    {
        public void MoveForward();
        public void TurnLeft();
        public void TurnRight();
        public Coordinate GetCurrenctCoordinate();
    }
}
