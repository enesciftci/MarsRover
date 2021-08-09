using MarsRover.Service.Service.Abstract;
using MarsRover.Service.Service.Constants;

namespace MarsRover.Service.Service.Concrete
{
    public class EastMovementState : BaseMovementState
    {
        public EastMovementState(Coordinate coordinate) : base(coordinate)
        {
        }

        public override void MoveForward() => base.Coordinate.SetStateX(Coordinate.X + 1);

        public override BaseMovementState TurnLeft() => new NorthMovementState(base.Coordinate);

        public override BaseMovementState TurnRight() => new SouthMovementState(base.Coordinate);

        public override string ToString() => PoleConstants.East.ToString();
    }
}
