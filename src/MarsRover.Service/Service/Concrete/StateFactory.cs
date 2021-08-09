using MarsRover.Service.Service.Abstract;
using MarsRover.Service.Service.Constants;
using System;

namespace MarsRover.Service.Service.Concrete
{
    public class StateFactory : IStateFactory
    {
        public BaseMovementState Create(Coordinate coordinate, char pole)
        {
            var newCoordinate = new Coordinate(coordinate.X, coordinate.Y);
            return pole switch
            {
                PoleConstants.South => new SouthMovementState(newCoordinate),
                PoleConstants.North => new NorthMovementState(newCoordinate),
                PoleConstants.West => new WestMovementState(newCoordinate),
                PoleConstants.East => new EastMovementState(newCoordinate),
                _ => throw new ArgumentOutOfRangeException("Please set movement direction range of (S,N,W,E)")
            };
        }
    }
}
