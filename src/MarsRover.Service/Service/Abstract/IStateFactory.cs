using MarsRover.Service.Service.Concrete;

namespace MarsRover.Service.Service.Abstract
{
    public interface IStateFactory
    {
        BaseMovementState Create(Coordinate coordinate, char pole);
    }
}
