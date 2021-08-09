using MarsRover.Service.Service.Abstract;

namespace MarsRover.Service.Service.Concrete
{
    public class Rover : IRover
    {
        private BaseMovementState _baseMovement;
        private IStateFactory _stateFactory;
        public Rover(IStateFactory stateFactory, Coordinate coordinate, char pole)
        {
            _stateFactory = stateFactory;
            _baseMovement = _stateFactory.Create(coordinate, pole);
        }
        public Coordinate GetCurrenctCoordinate() => _baseMovement.Coordinate;

        public void MoveForward() => _baseMovement.MoveForward();

        public void TurnLeft() => _baseMovement = _baseMovement.TurnLeft();

        public void TurnRight() => _baseMovement = _baseMovement.TurnRight();

        public override string ToString() => $"{this.GetCurrenctCoordinate()} {_baseMovement}";
    }
}
