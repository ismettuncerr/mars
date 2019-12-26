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
            Console.Write("İndirilecek Alanı Giriniz.(ör:5,5) :");
            var area = Convert.ToString(Console.ReadLine());
            string[] areas = area.Split(',');
            PlateauArea plateauArea = new PlateauArea(Convert.ToInt32(areas[0]), Convert.ToInt32(areas[1]));

            Console.Write("İndirilecek Rover Adedini Giriniz.(5) :");
            var roverCount = Convert.ToInt32(Console.ReadLine());

            List<RoverDetail> roverDetails = new List<RoverDetail>();
            for (int i = 0; i < roverCount; i++)
            {
                RoverDetail roverDetail = new RoverDetail();
                Console.Write("{0}. Robotun Başlangıç Koordinatını Giriniz.(ör:1,2) :", i + 1);
                var coordinate = Convert.ToString(Console.ReadLine());
                string[] coordinates = coordinate.Split(',');
                roverDetail.RoverPosition = new Position(Convert.ToInt32(coordinates[0]), Convert.ToInt32(coordinates[1]));

                Console.Write("{0}. Robotun Yönünü Giriniz.(ör:N) veya (ör:E) veya (ör:W) veya (ör:S) :",i+1);
                var direction = Convert.ToString(Console.ReadLine());
                System.Enum.TryParse(direction.ToUpper(), out Directions directions);
                roverDetail.RoverDirection = directions;

                Console.Write("{0}. Robotun Yapmasını istediğiniz hareketlerini giriniz.(ör:MMRMMRMRRM) :", i + 1);
                roverDetail.MoveDetail= Convert.ToString(Console.ReadLine());

                roverDetails.Add(roverDetail);
            }
            Console.WriteLine("");
            Console.WriteLine("Expected Output:");
            foreach (var rover in roverDetails)
            {
                MarsRover marsRover = new MarsRover(plateauArea, rover.RoverPosition, rover.RoverDirection);
                if (marsRover.Process(rover.MoveDetail))
                    Console.WriteLine(string.Format("{0} {1} {2}", marsRover.RoverPosition.X, marsRover.RoverPosition.Y, marsRover.RoverDirection));
            }

            Console.ReadLine();
        }
    }
}
