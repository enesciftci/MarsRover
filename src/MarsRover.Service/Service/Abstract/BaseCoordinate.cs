namespace MarsRover.Service.Service.Abstract
{
    public abstract class BaseCoordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public BaseCoordinate(int x, int y)
        {
            Y = y;
            X = x;
        }

        public void SetStateX(int x)
        {
            if (x > -1)
                X = x;
        }

        public void SetStateY(int y)
        {
            if (y > -1)
                Y = y;
        }
        public override string ToString() => $"{X} {Y}";
    }
}
