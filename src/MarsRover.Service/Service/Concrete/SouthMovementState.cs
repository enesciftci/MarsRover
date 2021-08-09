using MarsRover.Service.Service.Abstract;
using MarsRover.Service.Service.Constants;

namespace MarsRover.Service.Service.Concrete
{
    public class SouthMovementState : BaseMovementState
    {
        public SouthMovementState(Coordinate coordinate) : base(coordinate)
        {
        }
        public override void MoveForward() => base.Coordinate.SetStateY(base.Coordinate.Y - 1);
        public override BaseMovementState TurnLeft() => new EastMovementState(base.Coordinate);
        public override BaseMovementState TurnRight() => new WestMovementState(base.Coordinate);
        public override string ToString() => PoleConstants.South.ToString();
    }
}
