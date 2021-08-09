using MarsRover.Service.Service.Concrete;

namespace MarsRover.Service.Service.Abstract
{
    public abstract class BaseMovementState
    {
        public Coordinate Coordinate { get; private set; }
        public BaseMovementState(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }
        public abstract BaseMovementState TurnLeft();
        public abstract BaseMovementState TurnRight();
        public abstract void MoveForward();
    }
}
