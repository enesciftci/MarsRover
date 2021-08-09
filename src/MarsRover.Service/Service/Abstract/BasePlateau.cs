using MarsRover.Service.Service.Concrete;
using MarsRover.Service.Service.Constants;
using System;

namespace MarsRover.Service.Service.Abstract
{
    public abstract class BasePlateau
    {
        private int _endOfX { get; set; }
        private int _endOfY { get; set; }
        public Rover Rover;
        public BasePlateau(int endOfX, int endOfY)
        {
            _endOfX = endOfX;
            _endOfY = endOfY;
        }

        public void CheckLocationIsValid(Rover rover)
        {
            var currentCoordinate = rover.GetCurrenctCoordinate();
            if (currentCoordinate.X > _endOfX || currentCoordinate.Y > _endOfY)
                throw new ArgumentOutOfRangeException();
        }

        public void LocateToPosition(Rover rover)
        {
            CheckLocationIsValid(rover);
            Rover = rover;
        }

        public void MoveRover(char command)
        {
            switch (command)
            {
                case CommandConstants.MoveForward:
                    if (Rover.GetCurrenctCoordinate().X <= _endOfX && Rover.GetCurrenctCoordinate().Y <= _endOfY)
                        Rover.MoveForward();
                    break;
                case CommandConstants.TurnLeft:
                    Rover.TurnLeft();
                    break;
                case CommandConstants.TurnRight:
                    Rover.TurnRight();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
