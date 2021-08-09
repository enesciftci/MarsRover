using MarsRover.Service.Service.Abstract;
using MarsRover.Service.Service.Constants;
using System;

namespace MarsRover.Service.Service.Concrete
{
    public class NorthMovementState : BaseMovementState
    {
        public NorthMovementState(Coordinate coordinate) : base(coordinate)
        {

        }

        public override void MoveForward() => base.Coordinate.SetStateY(base.Coordinate.Y + 1);

        public override BaseMovementState TurnLeft() => new WestMovementState(base.Coordinate);

        public override BaseMovementState TurnRight() => new EastMovementState(base.Coordinate);

        public override string ToString() => PoleConstants.North.ToString();
    }
}
