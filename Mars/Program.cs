using Mars.Enum;
using Mars.Model;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Mars
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.Write("İndirilecek Alanı Giriniz.(ör:5,5)");
            var area = Convert.ToString(Console.ReadLine());
            string[] areas = area.Split(',');
            PlateauArea plateauArea = new PlateauArea(Convert.ToInt32(areas[0]), Convert.ToInt32(areas[1]));

            Console.Write("Robotun Başlangıç Koordinatını Giriniz.(ör:1,2)");
            var coordinate = Convert.ToString(Console.ReadLine());
            string[] coordinates = coordinate.Split(',');            
            var robotPosition = new Position(Convert.ToInt32(coordinates[0]), Convert.ToInt32(coordinates[1]));

            Console.Write("Robotun Yönünü Giriniz.(ör:N) veya (ör:E) veya (ör:W) veya (ör:S)");
            var direction = Convert.ToString(Console.ReadLine());
            System.Enum.TryParse(direction.ToUpper(), out Directions directions);
            var robotDirections = directions;

            Console.Write("Robotun Yapmasını istediğiniz hareketlerini giriniz.(ör:MMRMMRMRRM)");
            var move = Convert.ToString(Console.ReadLine());

            MarsRover marsRover = new MarsRover(plateauArea, robotPosition, robotDirections);
            if(marsRover.Process(move))
                Console.WriteLine(string.Format("{0} {1} {2}", marsRover.RoverPosition.X, marsRover.RoverPosition.Y, marsRover.RoverDirection));

            Console.ReadLine();
        }
    }
}
