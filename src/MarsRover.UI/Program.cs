using MarsRover.Service.Service.Abstract;
using MarsRover.Service.Service.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;

namespace MarsRover.UI
{
    class Program
    {
        private static IStateFactory _stateFactory;

        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            _stateFactory = serviceProvider.GetService<IStateFactory>();

            var lines = "5 5\r\n" +
                       "1 2 N\r\n" +
                       "LMLMLMLMM\r\n" +
                       "3 3 E\r\n" +
                       "MMRMMRMRRM";
            StringReader reader = new (lines);
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
                Console.WriteLine($"{plateau.Rover}");
            }
            Console.ReadKey();
        }
    }
}
