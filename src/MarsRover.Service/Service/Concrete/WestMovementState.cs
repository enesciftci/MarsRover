using MarsRover.Service.Service.Abstract;
using MarsRover.Service.Service.Constants;
using System;

namespace MarsRover.Service.Service.Concrete
{
    public class WestMovementState : BaseMovementState
    {
        public WestMovementState(Coordinate coordinate) : base(coordinate)
        {

        }

        public override void MoveForward() => base.Coordinate.SetStateX(base.Coordinate.X - 1);

        public override BaseMovementState TurnLeft() => new SouthMovementState(base.Coordinate);

        public override BaseMovementState TurnRight() => new NorthMovementState(base.Coordinate);

        public override string ToString() => PoleConstants.West.ToString();
    }
}
