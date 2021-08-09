using MarsRover.Service.Service.Abstract;
using MarsRover.Service.Service.Concrete;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace MarsRover.Test
{
    public class Tests
    {
        private IStateFactory _stateFactory;
        [SetUp]
        public void Setup()
        {
            _stateFactory = new StateFactory();
        }

        [TestCase("5 5\r\n" +
                       "1 2 N\r\n" +
                       "LMLMLMLMM\r\n" +
                       "3 3 E\r\n" +
                       "MMRMMRMRRM", ExpectedResult = "1 3 N5 1 E")]

        public string MoveRover_Succesfull(string lines)
        {
            StringBuilder output = new StringBuilder();
            StringReader reader = new(lines);
            var surfaceArea = reader.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var endOfX = surfaceArea[0];
            var endOfY = surfaceArea[1];
            Plateau plateau = new(endOfX, endOfY);
            while (true)
            {
                var locationAreaLine = reader.ReadLine();
                if (string.IsNullOrEmpty(locationAreaLine))
                    break;
                var locationArea = locationAreaLine.Split(" ");
                var x = Convert.ToInt32(locationArea[0]);
                var y = Convert.ToInt32(locationArea[1]);
                char pole = Convert.ToChar(locationArea[2]);

                Coordinate coordinate = new(x, y);
                Rover rover = new(_stateFactory, coordinate, pole);
                plateau.LocateToPosition(rover);
                var movementCommands = reader.ReadLine().ToList();
                movementCommands.ForEach(x => plateau.MoveRover(x));
                output.Append(plateau.Rover);
            }
            return output.ToString();
        }

        [TestCase(5, 5, 'N', ExpectedResult = "E")]
        public string TurnRight_Successfull(int x, int y, char pole)
        {
            BaseMovementState baseMovementState = _stateFactory.Create(new Coordinate(x, y), pole);
            baseMovementState = baseMovementState.TurnRight();
            return baseMovementState.ToString();
        }

        [TestCase(5, 5, 'N', ExpectedResult = "W")]
        public string TurnLeft_Successfull(int x, int y, char pole)
        {
            BaseMovementState baseMovementState = _stateFactory.Create(new Coordinate(x, y), pole);
            baseMovementState = baseMovementState.TurnLeft();
            return baseMovementState.ToString();
        }

        [TestCase(5, 5, 'N', ExpectedResult = "5 6")]
        public string MoveForward_Successfull(int x, int y, char pole)
        {
            BaseMovementState baseMovementState = _stateFactory.Create(new Coordinate(x, y), pole);
            baseMovementState.MoveForward();
            return $"{baseMovementState.Coordinate.X} {baseMovementState.Coordinate.Y}";
        }
    }
}